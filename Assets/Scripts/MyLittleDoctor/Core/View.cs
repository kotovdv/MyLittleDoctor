using UnityEngine;

namespace MyLittleDoctor.Core
{
    public abstract class View<TM, TV> : MonoBehaviour
        where TV : View<TM, TV>
        where TM : Model<TM, TV>
    {
        private TM _model;
        public TM Model => _model;

        public void AttachModel(TM model)
        {
            _model = model;
        }
    }
}