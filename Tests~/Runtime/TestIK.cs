using UnityEngine;

namespace Preliy.Flange
{
    [ExecuteAlways]
    public class TestIK : MonoBehaviour
    {
        [SerializeField]
        private Controller _controller;
        
        private void Update()
        {
            if (_controller == null) return;
            _controller.Solver.TryJumpToTarget(transform.GetMatrix(), SolutionIgnoreMask.All, false);
        }
    }
}
