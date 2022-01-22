using PS.Domain.Shared;

namespace PS.Domain.Service;

public class Level : Entity {

    public string Description {get;private set;}
    public TimeSpan ReponseTime {get;private set;}
    public Level(string description, TimeSpan reponseTime){

        Description = description ?? throw new ArgumentNullException(nameof(description));
        ReponseTime = reponseTime;
    }
    
}