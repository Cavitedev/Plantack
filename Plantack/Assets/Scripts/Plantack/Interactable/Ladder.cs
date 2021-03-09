using UnityEngine;

public class Ladder : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;


        var mover = collision.GetComponent<Plantack.Player.PlayerMover>();
        if (!mover.ladder)
            mover.ladder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;


        collision.GetComponent<Plantack.Player.PlayerMover>().ladder = false;
    }
}