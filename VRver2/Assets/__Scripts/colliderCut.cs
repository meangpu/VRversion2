using UnityEngine;
using Obi;

public class colliderCut : MonoBehaviour
{
 	ObiSolver solver;
    [SerializeField] string tagName = "kill";
	[SerializeField] string wantWireNameTag;
 
	void Awake(){
		solver = GetComponent<ObiSolver>();
	}

	void OnEnable () {
		solver.OnCollision += Solver_OnCollision;
	}

	void OnDisable(){
		solver.OnCollision -= Solver_OnCollision;
	}

	void Solver_OnCollision (object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
	{
		var world = ObiColliderWorld.GetInstance();

		// just iterate over all contacts in the current frame:
		foreach (Oni.Contact contact in e.contacts)
		{
			if (contact.distance < 0.01)
			{
				ObiColliderBase col = world.colliderHandles[contact.bodyB].owner;
				if (col != null)
				{
                    if (col.gameObject.tag == tagName)
                    {
                        int particleIndex = solver.simplices[contact.bodyA];
                        ObiSolver.ParticleInActor pa = solver.particleToActor[particleIndex];
                        ObiRope nowRope = pa.actor as ObiRope;  // get to rope script
                        meCutRope(nowRope, pa.indexInActor);  // get into actual index of rope
						if(nowRope.gameObject.tag != wantWireNameTag)
						{
							FindObjectOfType<AudioManager>().Play("BombButtonWrong");
							
							Timer[] allTimer = FindObjectsOfType<Timer>();
							foreach (Timer t in allTimer)
							{
								t.subtractTime(5f);
							}

							return;
						}
						else
						{
							AudioManager.instance.Play("BombButtonRight");
							QuestManager.Instance.finishQuestByName("Wire");
						}
                    }
				}
			}
		}
	}

    void meCutRope(ObiRope _rope, int _numIndex)
    {
        // prevent error out of list!!
        if(_rope.elements.Count > _numIndex)
        {
            _rope.Tear(_rope.elements[_numIndex]);
            _rope.RebuildConstraintsFromElements();
        }
    }








}
