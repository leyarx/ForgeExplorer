<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{3C054060-A8E9-4EF0-B3FF-CF1F62751676}</ProjectGuid>
    <OutputType>Library</OutputType>
    <RootNamespace>ForgeExplorer</RootNamespace>
    <AssemblyName>ForgeExplorer</AssemblyName>
    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
    <WarningLevel>4</WarningLevel>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <Deterministic>true</Deterministic>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup>
    <StartupObject />
  </PropertyGroup>
  <PropertyGroup>
    <SignAssembly>false</SignAssembly>
  </PropertyGroup>
  <PropertyGroup>
    <AssemblyOriginatorKeyFile>ForgeExplorer.snk</AssemblyOriginatorKeyFile>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Autodesk.Forge, Version=1.0.2.0, Culture=neutral, processorArchitecture=MSIL">
      <HintPath>..\packages\Autodesk.Forge.1.1.0\lib\45\Autodesk.Forge.dll</HintPath>
    </Reference>
    <Reference Include="Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
      <HintPath>..\packages\Microsoft.Xaml.Behaviors.Wpf.1.1.39\lib\net45\Microsoft.Xaml.Behaviors.dll</HintPath>
    </Reference>
    <Reference Include="Newtonsoft.Json, Version=9.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL">
      <HintPath>..\packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll</HintPath>
    </Reference>
    <Reference Include="RestSharp, Version=105.2.3.0, Culture=neutral, processorArchitecture=MSIL">
      <HintPath>..\packages\RestSharp.105.2.3\lib\net46\RestSharp.dll</HintPath>
    </Reference>
    <Reference Include="RevitAPI">
      <HintPath>..\..\..\..\..\..\Program Files\Autodesk\Revit 2020\RevitAPI.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="RevitAPIUI">
      <HintPath>..\..\..\..\..\..\Program Files\Autodesk\Revit 2020\RevitAPIUI.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Numerics" />
    <Reference Include="System.Web" />
    <Reference Include="System.Xml" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Xaml">
      <RequiredTargetFramework>4.0</RequiredTargetFramework>
    </Reference>
    <Reference Include="WindowsBase" />
    <Reference Include="PresentationCore" />
    <Reference Include="PresentationFramework" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Commands\ExplorerCommand.cs" />
    <Compile Include="Application.cs" />
    <Compile Include="Core\AsyncCommandBase.cs" />
    <Compile Include="Core\AsyncRelayCommand.cs" />
    <Compile Include="Core\RelayCommand.cs" />
    <Compile Include="Models\Credentials.cs" />
    <Compile Include="Models\DataManagementController.cs" />
    <Compile Include="Models\Item.cs" />
    <Compile Include="ViewModels\ItemViewModel.cs" />
    <Compile Include="ViewModels\ViewModelBase.cs" />
    <Compile Include="ViewModels\ExplorerViewModel.cs" />
    <Compile Include="Views\ExplorerView.xaml.cs">
      <DependentUpon>ExplorerView.xaml</DependentUpon>
    </Compile>
    <Compile Include="Views\MainWindow.xaml.cs">
      <DependentUpon>MainWindow.xaml</DependentUpon>
    </Compile>
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="Properties\Resources.Designer.cs">
      <AutoGen>True</AutoGen>
      <DesignTime>True</DesignTime>
      <DependentUpon>Resources.resx</DependentUpon>
    </Compile>
    <Compile Include="Properties\Settings.Designer.cs">
      <AutoGen>True</AutoGen>
      <DependentUpon>Settings.settings</DependentUpon>
      <DesignTimeSharedInput>True</DesignTimeSharedInput>
    </Compile>
    <EmbeddedResource Include="Properties\Resources.resx">
      <Generator>ResXFileCodeGenerator</Generator>
      <LastGenOutput>Resources.Designer.cs</LastGenOutput>
    </EmbeddedResource>
    <None Include="ForgeExplorer.addin" />
    <None Include="ForgeExplorer.snk" />
    <None Include="packages.config" />
    <None Include="Properties\Settings.settings">
      <Generator>SettingsSingleFileGenerator</Generator>
      <LastGenOutput>Settings.Designer.cs</LastGenOutput>
    </None>
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
  </ItemGroup>
  <ItemGroup>
    <Page Include="Views\ExplorerView.xaml">
      <SubType>Designer</SubType>
      <Generator>MSBuild:Compile</Generator>
    </Page>
    <Page Include="Views\MainWindow.xaml">
      <SubType>Designer</SubType>
      <Generator>MSBuild:Compile</Generator>
    </Page>
  </ItemGroup>
  <ItemGroup>
    <Resource Include="Resources\open-folder_16x16.png" />
    <Resource Include="Resources\open-folder_32x32.png" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>