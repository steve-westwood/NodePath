namespace Core
{
	public class Edge
	{
		public virtual Vertex Vertex { get; set; }
		public virtual int OriginID { get; set; }
		public virtual int DestinationID { get; set; }
		
		public override bool Equals(object obj)
		{
			var other = obj as Edge;

			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return this.OriginID == other.OriginID &&
				this.DestinationID == other.DestinationID;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = GetType().GetHashCode();
				hash = (hash * 31) ^ OriginID.GetHashCode();
				hash = (hash * 31) ^ DestinationID.GetHashCode();

				return hash;
			}
		}
	}
}
