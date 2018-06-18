using DatabaseRelationGraph.Models;
using System.ComponentModel;

namespace DatabaseRelationGraph.ViewModels
{
    public abstract class VMBase<M> : INotifyPropertyChanged
        where M : class, new()
    {
        public VMBase(M model)
        {
            Model = model;
        }

        private protected M Model { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName ?? string.Empty));
        }
    }
}
