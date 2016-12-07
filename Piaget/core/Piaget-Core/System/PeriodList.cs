// A tester : si la liste des période a été vidée, est-ce qu'on appellera quand

using Piaget_Core.Lib;
using System;

namespace Piaget_Core.System {
    class PeriodNode : DoubleLinkedNode<PeriodNode> {
        public ulong period;
    }

    class PeriodList : DoubleLinkedListSorted<PeriodNode> {

        static private ulong get_period (PeriodNode period_node) {
            return period_node.period;
        }

        public PeriodList() : base(get_period) {}

        public void Add(ulong period) {
            this.Add(new PeriodNode { period = period });
        }
    }
}
