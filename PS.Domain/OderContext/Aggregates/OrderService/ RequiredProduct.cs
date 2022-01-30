using PS.Domain.Shared;
namespace PS.Domain.OderContext.Aggregates.OrderService;
public class  RequiredProduct : Entity
{
    public string Description {get;private set;}
    public bool Checked {get;private set;}
    public RequiredProduct(string description,bool @checked){
        Description = description;
        Checked = @checked;
    }
}