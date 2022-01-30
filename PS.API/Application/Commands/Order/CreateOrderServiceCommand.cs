using System.Runtime.Serialization;
using MediatR;

namespace PS.API.Application.Commands.Order;


[DataContract]
public class CreateOrderServiceCommand : IRequest<bool>{

    [DataMember]
    public int CustomerId { get; private set; }

    [DataMember]
    public string ServiceName { get; private set; }

    [DataMember]
    public string ServiceDescription { get; private set; }

    [DataMember]
    private readonly List<RequiredProductDTO> _requiredProduts;
    [DataMember]
    public IEnumerable<RequiredProductDTO> RequiredProductDTOs => _requiredProduts;

    [DataMember]
    public TimeSpan ResponseTime {get;private set;}

    public CreateOrderServiceCommand()
    {
        _requiredProduts = new List<RequiredProductDTO>();
    }

    public CreateOrderServiceCommand(
        int customerId,
        string serviceName,
        string serviceDescription,
        TimeSpan responseTime,
        List<RequiredProductDTO> requiredProduts){

        CustomerId = customerId;
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        _requiredProduts = requiredProduts;
    }

}

public record RequiredProductDTO {

    public int Id { get; init; }
    public string Description { get; init; }
    public bool Checked {get;init;}

}

