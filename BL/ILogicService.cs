using Core;

namespace Services
{
	public interface ILogicService
	{
		void SaveVertices(Vertex[] vertices);

		Vertex[] GetVertices();

		int[] FindShortestPath(int start, int finish);
	}
}
