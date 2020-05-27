namespace MyLittleDoctor.Core
{
    public abstract class Model<TM, TV>
        where TV : View<TM, TV>
        where TM : Model<TM, TV>
    {
        private TV _view;
        public TV View => _view;

        public void AttachView(TV view)
        {
            _view = view;
        }
    }
}