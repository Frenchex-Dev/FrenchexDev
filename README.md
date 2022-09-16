# Frenchex.Dev
A Software Factory for developers

I often manage multiple projects on different docker machines.

Sometimes I have to create a new environment for a specific project : its gitlab, its CI nodes, etc.
It can be Virtual machine needs or containers needs.

My approach is to use VirtualBox, driven by Vagrant, to help me manage my projects environments.

So I can have multiple running k8s clusters on my computer running differents projects at same time.

I can run tests on one project and continue developing another.

Or it avoids me having only one environment and having to hack every time I need to switch.

Finally it helps me out manage multiple development environments by means of Virtual Machines that are providing Docker hosts.

There are commands helping managing VMs and projects, you can also group them and type them.

It's easy when splitting Products, which are made of projects of many kinds.

On the .sln side, I use to split my products into multiple coherent projects

![image](https://user-images.githubusercontent.com/247398/190094221-30e3c77b-491c-4bc9-a80a-5061733d19e3.png)

![image](https://user-images.githubusercontent.com/247398/190505160-7c421b35-c8c8-4153-8b4a-b404cf3ebf67.png)


## Dependencies
 - vagrant
 - virtualbox
 
 ## Architecture of the Solution
 
Every products are in their own Solution Folder.

![image](https://user-images.githubusercontent.com/247398/190094772-83840e6e-df1b-491e-a663-b0509c7b6c3d.png)

 
 ### Dependencies
 
 All dependencies are caught in a project of their own.
 
 ![image](https://user-images.githubusercontent.com/247398/190093892-68a20232-d697-42ec-8ce4-75907bff0194.png)

 ### CLI, Lib, WebApi, WebUI, Tests
 
 Proudcts are meant to be usable in many ways, as libs, as webapi, as CLI, whatever.
 
 ![image](https://user-images.githubusercontent.com/247398/190096203-bfd59336-a538-4df9-b5b7-505ed7722f27.png)

 
 
 * Lib : contains business code
 
 ![image](https://user-images.githubusercontent.com/247398/190095383-a441e6b6-89a9-4e5e-ad7d-e960d2ba0ce6.png)

 * Lib.Tests : contains business workflows unit tests
 
 ![image](https://user-images.githubusercontent.com/247398/190095527-a1bbe3fb-6d97-437e-a308-e4655360d75b.png)

 * Cli.Integration.Lib : contains integration to CLI tooling 
 ![image](https://user-images.githubusercontent.com/247398/190096430-54627e0d-f263-4473-86ab-6249dcb2512f.png)

  
 * Cli.Integration.Lib.Tests : contains business workflows unit testing CLI integration
 ![image](https://user-images.githubusercontent.com/247398/190095262-d14dad6f-9d0f-42a7-8104-4d14216fdbee.png)
