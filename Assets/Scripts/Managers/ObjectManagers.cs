using Model;

namespace Managers
{
    public class ObjectManagers : Singleton<ObjectManagers>
    {
        public Command[] Commands;
    }
}