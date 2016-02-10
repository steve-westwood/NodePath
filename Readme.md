<h1>NodePath</h1>

Application to find the shortest path between to vertices using Breadth First Search algorithm.

<h1>Database </h1>

A MSSQL Database backup can be found in the root directory called "NodePath.bak", restore this and replace the connection settings in the file DL&gt;Repository.cs.

<h1>WebApi</h1>

Three endpoints exist for the API. They are:
<ul>
<li>&lt;ApiUrl&gt;/installer/save - POST - which expects Core.Vertex[] to be posted</li>
<li>&lt;ApiUrl&gt;/frontend/get - GET - retrieves Core.Vertex[] data</li>
<li>&lt;ApiUrl&gt;/logic/findshortestpath/{start}/{end} - GET - which given a start Vertex.ID {int} and a end Vertex.ID {int} return a int[] of the shortest path.</li>
</ul>
<h1>Installer Console Application</h1>

The Web Api base URL is stored in the Importer&gt;App.config under the node appSettings&gt;ApiUrl