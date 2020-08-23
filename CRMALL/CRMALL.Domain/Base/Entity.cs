using Flunt.Notifications;

namespace CRMALL.Domain.Base
{
    public class Entity : Notifiable
    {
        public Entity()
        {
        }

        public int Id { get; set; }
    }
}
