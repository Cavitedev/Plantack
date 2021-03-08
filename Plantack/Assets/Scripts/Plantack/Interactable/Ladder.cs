using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
            return;
        else
        {
            var mover = collision.GetComponent<Plantack.Player.PlayerMover>();
            if (!mover.ladder)
                mover.ladder = true;
            else return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
            return;
        else
        {
            collision.GetComponent<Plantack.Player.PlayerMover>().ladder = false;
        }
    }
}
