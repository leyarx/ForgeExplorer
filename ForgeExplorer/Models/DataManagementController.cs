using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Autodesk.Forge;
using Autodesk.Forge.Model;

namespace ForgeExplorer.Models
{
    public class DataManagementController
    {
        private Credentials Credentials { get; set; }

        public async Task<string> GetUserProfileAsync()
        {
            string name = string.Empty;

            UserProfileApi userProfileApi = new UserProfileApi();
            userProfileApi.Configuration.AccessToken = Credentials.TokenInternal;

            try
            {
                dynamic user = await userProfileApi.GetUserProfileAsync();

                name = user.ToString();
                Debug.Write(name);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return name;
        }

        public async Task<IList<Item>> GetItemAsync(string id)
        {
            if (Credentials == null) {

                Credentials = Credentials.GetFromAdWebServices();

                if (Credentials == null)
                {
                    return null;
                } 
            }

            IList<Item> nodes = new List<Item>();

            if (id == "#") // root
                return await GetHubsAsync();
            else
            {
                string[] idParams = id.Split('/');
                string resource = idParams[idParams.Length - 2];
                switch (resource)
                {
                    case "hubs": // hubs node selected/expanded, show projects
                        return await GetProjectsAsync(id);
                    case "projects": // projects node selected/expanded, show root folder contents
                        return await GetProjectContents(id);
                    case "folders": // folders node selected/expanded, show folder contents
                        return await GetFolderContents(id);
                    //case "items":
                    //    return await GetItemVersions(id);
                }
            }

            return nodes;
        }

        private async Task<IList<Item>> GetHubsAsync()
        {
            IList<Item> items = new List<Item>();

            // the API SDK
            HubsApi hubsApi = new HubsApi();
            hubsApi.Configuration.AccessToken = Credentials.TokenInternal;

            var hubs = await hubsApi.GetHubsAsync();
            foreach (KeyValuePair<string, dynamic> hubInfo in new DynamicDictionaryItems(hubs.data))
            {
                // check the type of the hub to show an icon
                string nodeType = "hubs";
                switch ((string)hubInfo.Value.attributes.extension.type)
                {
                    case "hubs:autodesk.core:Hub":
                        nodeType = "unsupported";
                        break;
                    case "hubs:autodesk.a360:PersonalHub":
                        nodeType = "unsupported";
                        break;
                    case "hubs:autodesk.bim360:Account":
                        nodeType = "bim360Hubs";
                        break;
                }

                // create an item with the values
                Item hubNode = new Item(hubInfo.Value.links.self.href, hubInfo.Value.attributes.name, nodeType, !(nodeType == "unsupported"));
                items.Add(hubNode);
            }

            return items;
        }

        private async Task<IList<Item>> GetProjectsAsync(string href)
        {
            IList<Item> items = new List<Item>();

            // the API SDK
            ProjectsApi projectsApi = new ProjectsApi();
            projectsApi.Configuration.AccessToken = Credentials.TokenInternal;

            // extract the hubId from the href
            string[] idParams = href.Split('/');
            string hubId = idParams[idParams.Length - 1];

            var projects = await projectsApi.GetHubProjectsAsync(hubId);
            foreach (KeyValuePair<string, dynamic> projectInfo in new DynamicDictionaryItems(projects.data))
            {
                // check the type of the project to show an icon
                string nodeType = "projects";
                switch ((string)projectInfo.Value.attributes.extension.type)
                {
                    case "projects:autodesk.core:Project":
                        nodeType = "a360projects";
                        break;
                    case "projects:autodesk.bim360:Project":
                        nodeType = "bim360projects";
                        break;
                }

                // create a Item with the values
                Item projectNode = new Item(projectInfo.Value.links.self.href, projectInfo.Value.attributes.name, nodeType, true);
                items.Add(projectNode);
            }

            return items;
        }

        private async Task<IList<Item>> GetProjectContents(string href)
        {
            // the API SDK
            ProjectsApi projectApi = new ProjectsApi();
            projectApi.Configuration.AccessToken = Credentials.TokenInternal;

            // extract the hubId & projectId from the href
            string[] idParams = href.Split('/');
            string hubId = idParams[idParams.Length - 3];
            string projectId = idParams[idParams.Length - 1];

            var project = await projectApi.GetProjectAsync(hubId, projectId);
            var rootFolderHref = project.data.relationships.rootFolder.meta.link.href;

            return await GetFolderContents(rootFolderHref);
        }

        private async Task<IList<Item>> GetFolderContents(string href)
        {
            IList<Item> folderItems = new List<Item>();

            // the API SDK
            FoldersApi folderApi = new FoldersApi();
            folderApi.Configuration.AccessToken = Credentials.TokenInternal;

            // extract the projectId & folderId from the href
            string[] idParams = href.Split('/');
            string folderId = idParams[idParams.Length - 1];
            string projectId = idParams[idParams.Length - 3];

            var folderContents = await folderApi.GetFolderContentsAsync(projectId, folderId);
            foreach (KeyValuePair<string, dynamic> folderContentItem in new DynamicDictionaryItems(folderContents.data))
            {
                string displayName = folderContentItem.Value.attributes.displayName;
                if (string.IsNullOrWhiteSpace(displayName))
                {
                    continue;
                }

                Item itemNode = new Item(folderContentItem.Value.links.self.href, displayName, (string)folderContentItem.Value.type, true);

                folderItems.Add(itemNode);
            }

            return folderItems;
        }
    }
}
