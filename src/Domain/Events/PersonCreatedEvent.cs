namespace Connectlime.Domain.Events;

public class PersonCreatedEvent : BaseEvent
{
    public Person Person { get; }

    public PersonCreatedEvent(Person person)
    {
        Person = person;
    }
}
