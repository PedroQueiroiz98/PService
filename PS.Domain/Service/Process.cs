using PS.Domain.Shared;

namespace PS.Domain.Service;


public class Process : Entity {
    

    public string Description {get;private set;}
    public bool Required {get;private set;}
    public Process(string description,bool required){
        Description = description;
        Required = required;
    }

}