namespace Plantack.Interactable
{
    public interface IInteractable
    {
        public delegate void Interact();

        public Interact GetInteractDelegate();

        public void Exit();

    }
}