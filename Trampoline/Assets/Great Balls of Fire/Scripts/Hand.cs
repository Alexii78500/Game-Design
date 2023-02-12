using UnityEngine;

public class Hand : MonoBehaviour
{
  public Transform ball;
  private Rigidbody rb;

  void Start()
  {
    rb = ball.gameObject.AddComponent<Rigidbody>();
    rb.useGravity = false;
  }
    // Start is called before the first frame update

    public void Release()
    {
      rb.useGravity = true;
    }

    public void Reset()
    {
      ball.transform.position = this.gameObject.transform.position;
      rb.useGravity = false;
      rb.velocity = Vector3.zero;
    }
}
