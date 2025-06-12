using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Mathf;

namespace Preliy.Flange
{
    [AddComponentMenu("Robotics/Robot 6R Lobster Wrist")]
    [DisallowMultipleComponent]
    [SelectionBase]
    public class Robot6RLobsterWrist : Robot
    {
        private const int FRAME_COUNT = 8;
        private const int JOINT_COUNT = 6;
        private const int DEFAULT_SOLUTIONS_COUNT = 8;

        private readonly static List<int> InverseIndex = new() {2, 3, 6, 7};
       
        private Vector4 _p65;
        private float _l1, _l2, _delta;
        private float _x, _y, _l, _alpha, _beta, _gamma;
        private Matrix4x4 _t01, _t12, _t23,_t34, _t03, _t36, _target;
        private Vector3 _p05, _p3Dist;
        private readonly float[] _theta = new float[JOINT_COUNT];

        private Matrix4x4 _t14, _t16, _t45, _t56, _t61;
        private Matrix4x4 _t5;
        // ReSharper disable once InconsistentNaming
        private float _p5xz;
        private float _psi, _phi;
        private float _sin1, _cos1, _p13Dist;

        private void Reset()
        {
            _frames = new List<Frame>();
            for (var i = 0; i < FRAME_COUNT; i++)
            {
                _frames.Add(null);
            }

            _joints = new List<TransformJoint>();
            for (var i = 0; i < JOINT_COUNT; i++)
            {
                _joints.Add(null);
            }
        }
        
#if UNITY_EDITOR
        [ContextMenu("Create Default Hierarchy", false, 500)]
        public void CreateDefaultHierarchy()
        {
            _frames = new List<Frame>();
            _joints = new List<TransformJoint>();

            var baseFrame = transform.GetOrCreate("Base").CreateMeshPlaceholder();
            _frames.Add(baseFrame);

            var parent = baseFrame.transform;
            for (var i = 0; i < JOINT_COUNT; i++)
            {
                var frame = parent.GetOrCreate($"Joint_{i + 1}").CreateMeshPlaceholder();
                _joints.Add(frame.TryGetComponent<TransformJoint>(out var joint) ? joint : frame.gameObject.AddComponent<TransformJoint>());
                parent = frame.transform;
                _frames.Add(frame);
            }

            var flangeFrame = parent.GetOrCreate("Flange");
            _frames.Add(flangeFrame);
        }
#endif

        public override Matrix4x4 ComputeForward()
        {
            return _frames.First().transform.GetMatrix().inverse * _frames.Last().transform.GetMatrix();
        }

        public override IKSolution ComputeInverse(Matrix4x4 target, Configuration configuration, SolutionIgnoreMask ignoreMask)
        {
            //TODO
            Debug.Log("ComputeInverse");
            
            /*var solutionIndex = Clamp(configuration.Index, 0, DEFAULT_SOLUTIONS_COUNT - 1);

            _t56 = HomogeneousMatrix.CreateRaw(_frames[6].Config);
            _t5 = target * _t56.inverse;

            _p05 = _t5.GetPosition();

            //THETA1
            _p5xz = Sqrt(Pow(-_p05.x, 2) + Pow(_p05.z, 2));
            _psi = Atan2(-_p05.x, _p05.z);
            _phi = Acos(_frames[4].Config.D / _p5xz);
            _theta[0] = solutionIndex < 4 ? _psi + _phi + PI * 0.5f : _psi - _phi + PI * 0.5f;

            //THETA5
            _t01 = HomogeneousMatrix.CreateRaw(_frames[1].Config, _theta[0]);
            _t16 = _t01.inverse * target;
            _theta[4] = -Acos((_t16.m13 - _frames[4].Config.D) / _frames[6].Config.D);
            if (InverseIndex.Contains(solutionIndex)) _theta[4] *= -1;
            
            //THETA6
            _t61 = _t16.inverse;
            var sin5 = Sin(_theta[4]);
            if (Approximately(sin5, 0f))
            {
                _theta[5] = 0f;
            }
            else
            {
                _theta[5] = Atan2(_t61.m01 / sin5, _t61.m21 / sin5);
            }

            //THETA3
            _t56 = HomogeneousMatrix.CreateRaw(_frames[6].Config, _theta[5]);
            _t45 = HomogeneousMatrix.CreateRaw(_frames[5].Config, _theta[4]);
            _t14 = _t16 * _t56.inverse * _t45.inverse;
            _p3Dist = _t14.GetPosition();
            _p13Dist = Sqrt(Pow(_p3Dist.z, 2) + Pow(_p3Dist.x, 2));
            _theta[2] = Acos((Pow(_p13Dist, 2) - Pow(_frames[2].Config.A, 2) - Pow(_frames[3].Config.A, 2)) / (2 * _frames[2].Config.A * _frames[3].Config.A));
            _theta[2] = solutionIndex % 2 == 0 ? _theta[2] : -_theta[2];
            
            //THETA2
            _theta[1] = Atan2(-_p3Dist.z, -_p3Dist.x) - Asin(-_frames[3].Config.A * Sin(_theta[2]) / _p13Dist) - PI * 0.5f;

            //THETA4
            _t23 = HomogeneousMatrix.CreateRaw(_frames[3].Config, _theta[2]);
            _t12 = HomogeneousMatrix.CreateRaw(_frames[2].Config, _theta[1]);
            _t34 = _t23.inverse * _t12.inverse * _t14;
            _theta[3] = Atan2(-_t34.m22, -_t34.m02) + PI * 0.5f;*/

            return CreateSolution(_theta, configuration, ignoreMask);
        }
        
        public override List<IKSolution> ComputeInverse(Matrix4x4 target, bool turn, SolutionIgnoreMask ignoreMask)
        {
            var solutions = new List<IKSolution>();
            for (var i = 0; i < DEFAULT_SOLUTIONS_COUNT; i++)
            {
                try
                {
                    var configuration = new Configuration(0,0,0,i);
                    var solution = ComputeInverse(target, configuration, ignoreMask);
                    if (solution.IsValid)
                    {
                        if (turn)
                        {
                            solutions.AddRange(GetSolutionsWithTurns(solution, i));
                        }
                        else
                        {
                            solutions.Add(solution);
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }
            return solutions;
        }
        
        public override int GetConfigurationIndex(float[] jointValues)
        {
            var frame1 = HomogeneousMatrix.Create(_frames[1].Config, _joints[0].Config, jointValues[0]);
            var frame2 = frame1 * HomogeneousMatrix.Create(_frames[2].Config, _joints[1].Config, jointValues[1]);
            var frame3 = frame2 * HomogeneousMatrix.Create(_frames[3].Config, _joints[2].Config, jointValues[2]);
            var frame4 = frame3 * HomogeneousMatrix.Create(_frames[4].Config, _joints[3].Config, jointValues[3]);
            var frame5 = frame4 * HomogeneousMatrix.Create(_frames[5].Config, _joints[4].Config, jointValues[4]);
            var frame6 = frame5 * HomogeneousMatrix.Create(_frames[6].Config, _joints[5].Config, jointValues[5]);

            var diff = frame1.inverse.MultiplyPoint3x4(frame6.GetPosition());
            var isBack = diff.z < 0.0f;
            var directionJ3 = frame2.GetPosition() - frame1.GetPosition(); 
            var directionJ5 = frame4.GetPosition() - frame1.GetPosition(); 
            var isDown = Vector3.SignedAngle(directionJ3, directionJ5, frame1.GetUpDirection()) < 0.0f;
            var isFlip = Abs(jointValues[3]) > 0f;

            var bitArray = new BitArray(3)
            {
                [2] = isBack,
                [1] = isDown,
                [0] = isFlip
            };
            var array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
        
        public override int GetConfigurationIndex()
        {
            var isBack = _joints[0].transform.InverseTransformPoint(_joints[4].transform.position).z > 0.0f;
            var directionJ3 = _joints[1].transform.position - _joints[0].transform.position; 
            var directionJ5 = _joints[3].transform.position - _joints[0].transform.position; 
            var isDown = Vector3.SignedAngle(directionJ3, directionJ5, _joints[0].transform.up) > 0.0f;
            var isFlip = Abs(_joints[3].Position.Value) < 0f;

            var bitArray = new BitArray(3)
            {
                [2] = isBack,
                [1] = isDown,
                [0] = isFlip
            };
            var array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
        
#if UNITY_EDITOR
        public override void DrawDebugGizmos()
        {
            
        }
#endif
        
        private IKSolution CreateSolution(float[] theta, Configuration configuration, SolutionIgnoreMask ignoreMask)
        {
            for (var i = 0; i < theta.Length; i++)
            {
                if (float.IsNaN(_theta[i])) return IKSolution.IKSolutionNaN;
                theta[i] *= Rad2Deg;
                theta[i] -= _joints[i].Config.Offset;
                theta[i] = theta[i].Round(3);
            }
            
            var jointTarget = new JointTarget(theta);

            for (var i = 0; i < theta.Length; i++)
            {
                theta[i] = theta[i].Round(3);

                if (!_joints[i].IsInRange(theta[i]))
                {
                    return new IKSolution($"Joint {i + 1} value {theta[i]} is out of range [{_joints[i].Config.Limits.ToString()}]");
                }
            }
            
            //TODO Solution Check
            if (!ignoreMask.HasFlag(SolutionIgnoreMask.Singularity))
            {
                //Some check
            }
            
            var solution = new IKSolution(jointTarget, configuration);
            solution.Validate(this);
            return solution;
        }
        
        private IEnumerable<IKSolution> GetSolutionsWithTurns(IKSolution defaultSolution, int cfx)
        {
            var solutions = new List<IKSolution>();
            var configurations = new List<Configuration>();

            List<int> turnsJ0 = JointUtils.GetTurns(_joints[0].Config, defaultSolution.JointTarget[0]);
            List<int> turnsJ3 = JointUtils.GetTurns(_joints[3].Config, defaultSolution.JointTarget[3]);
            List<int> turnsJ5 = JointUtils.GetTurns(_joints[5].Config, defaultSolution.JointTarget[5]);

            foreach (var j0 in turnsJ0)
            {
                foreach (var j3 in turnsJ3)
                {
                    foreach (var j5 in turnsJ5)
                    {
                        var configuration = new Configuration(j0, j3, j5, cfx);
                        if (configurations.Contains(configuration)) continue;
                        configurations.Add(configuration);
                    }
                }
            }

            foreach (var configuration in configurations)
            {
                var solution = new IKSolution(defaultSolution.JointTarget, configuration);
                solution.Validate(this);
                if (solution.IsValid) solutions.Add(solution);
            }

            return solutions;
        }
    }
}
