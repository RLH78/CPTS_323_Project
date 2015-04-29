
namespace TargetServerCommunicator.Data
{
	/// <summary>
	/// Holds information about a target sent from the game server.
	/// </summary>
    public class Target
    {
		 /// <summary>
		 /// gets or sets the unique id of the target.
		 /// </summary>
        public int id { get; set; }
		 /// <summary>
		 /// Gets or sets if this is a friend (0 for enemy, 1 for friend)
		 /// </summary>
        public int status { get; set; }
		 /// <summary>
		 /// Gets or sets how many times the target was hit.
		 /// </summary>
        public int hit { get; set; }
		 /// <summary>
		 /// Gets or sets whether the target is moving (i.e. blink)
		 /// </summary>
        public bool movingState { get; set; }
		 /// <summary>
		 /// Gets or sets the led pin id
		 /// </summary>
        public int led { get; set; }
		 /// <summary>
		 /// gets or sets the target name.
		 /// </summary>
        public string name { get; set; }
		 /// <summary>
		 /// Gets or sets the spawn rate (in seconds) of the target.
		 /// </summary>
        public double spawnRate { get; set; }
		 /// <summary>
		 /// Gets or sets if the target can move.
		 /// </summary>
        public bool isMoving { get; set; }
		 /// <summary>
		 /// Gets or sets how much the target is worth.
		 /// </summary>
        public double points { get; set; }
		 /// <summary>
		 /// Gets or sets the start time 
		 /// </summary>
        public double startTime { get; set; }
		 /// <summary>
		 /// gets or sets the x position of the target
		 /// </summary>
        public double x { get; set; }
		 /// <summary>
		 /// gets or sets the y position of the target.
		 /// </summary>
        public double y { get; set; }
		 /// <summary>
		 /// gets or sets the z position of the target.
		 /// </summary>
        public double z { get; set; }
		 /// <summary>
		 /// gets or sets the input pin for GPIO
		 /// </summary>
		  public int input { get; set; }
		 /// <summary>
		 /// gets or sets how often or fast the led's blink (in seconds)
		 /// </summary>
		  public double dutyCycle { get; set; }
		 /// <summary>
		 /// gets or sets whether a target can swap sides
		 /// </summary>
		  public bool canChangeSides { get; set; }
		 /// <summary>
		 /// gets or sets the score accumulated for this target.
		 /// </summary>
	    public double score { get; set; }
    }
}
