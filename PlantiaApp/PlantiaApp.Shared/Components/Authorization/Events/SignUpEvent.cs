namespace PlantiaApp.Shared.Components.Authorization.Events;

using PlantiaApp.Shared.Core.Events;

using PlantiaApp.Shared.Components.Authorization.Records;
using PlantiaApp.Shared.Components.Authorization.Interfaces;
using PlantiaApp.Shared.Core.Interfaces;



public class SignUpProducer : BaseProducer
{
    public void AnyBussinessRole(SignUpInput signUpInput)
    {
        // TODO: Validar a inserção do Usuário para poder notificar os Subscribers
        Notify();
    }

}

public class SendEmailSignUpSubscriber : ISubscriber
{
    public void Update(IProducer Producer)
    {
        // TODO: Enviar email para o Usuário inscrito
    }

}
