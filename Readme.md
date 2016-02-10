NodePath

Application to find the shortest path between to vertices using Breadth First Search algorithm.

Database 

A MSSQL Database backup can be found in the root directory called "NodePath.bak", restore this and replace the connection settings in the file DL>Repository.cs.

WebApi

Three endpoints exist for the API. They are:

<ApiUrl>/installer/save - POST - which expects Core.Vertex[] to be posted
<ApiUrl>/frontend/get - GET - retrieves Core.Vertex[] data
<ApiUrl>/logic/findshortestpath/{start}/{end} - GET - which given a start Vertex.ID {int} and a end Vertex.ID {int} return a int[] of the shortest path.

Installer Console Application

The Web Api base URL is stored in the Importer>App.config under the node appSettings>ApiUrl