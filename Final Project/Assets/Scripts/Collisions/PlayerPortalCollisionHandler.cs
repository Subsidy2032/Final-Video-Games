using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortalCollisionHandler : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        Collider2D thisCollider = GetComponent<Collider2D>();

        if (thisCollider != null && thisCollider.isTrigger)
        {
            if (collision.CompareTag(ObjectTagsEnum.Player.ToString()) && IsOutOfBounds(collision.gameObject, gameObject.tag))
            {
                SceneManagerWrapper.GetInstance().LoadScene(SceneNamesEnum.LoseScreen.ToString());
            }
        }

    }

    public bool IsOutOfBounds(GameObject player, string tag)
    {
        GameObject block = GameObject.FindWithTag(tag);
        float playerXPosition = player.transform.position.x;
        float playerYPosition = player.transform.position.y;

        float blockXPosition = block.transform.position.x;
        float blockYPosition = block.transform.position.y;

        if (tag == ObjectTagsEnum.LeftWall.ToString() && playerXPosition < blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.RightWall.ToString() && playerXPosition > blockXPosition)
            return true;

        if (tag == ObjectTagsEnum.Ground.ToString() && playerYPosition < blockYPosition)
            return true;

        if (tag == ObjectTagsEnum.Ceiling.ToString() && playerYPosition > blockYPosition)
            return true;

        return false;
    }
}
