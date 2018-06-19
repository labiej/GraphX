using DatabaseRelationGraph.Models;
using System.ComponentModel;

namespace DatabaseRelationGraph.ViewModels
{
    public abstract class VMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
        }
    }

    public abstract class VMBase<M> : VMBase
        where M : class, new()
    {
        public VMBase(M model)
        {
            Model = model;
        }

        private protected M Model { get; set; }
    }
}
