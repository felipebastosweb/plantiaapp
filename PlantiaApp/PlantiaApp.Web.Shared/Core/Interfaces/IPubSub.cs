using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantiaApp.Shared.Core.Interfaces;

public interface IProducer
{
    void Attach(ISubscriber subscriber);
    void Detach(ISubscriber subscriber);
    void Notify();
}
public interface ISubscriber
{
    void Update(IProducer Producer);
}
