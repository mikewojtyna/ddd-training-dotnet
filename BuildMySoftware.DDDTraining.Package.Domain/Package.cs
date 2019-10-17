using System;

namespace BuildMySoftware.DDDTraining.Package
{
    public class Package
    {
        private bool _state1;
        private bool _state2;
        private MessageCollector _messageCollector;

        public Package(MessageCollector messageCollector)
        {
            _state1 = true;
            _messageCollector = messageCollector;
        }

        public void Operation()
        {
            if (_state1)
            {
                HandleState1();
                _state1 = false;
                _state2 = true;
            }
            else if (_state2)
            {
                HandleState2();
                _state1 = true;
                _state2 = false;
            }
            // repeat this some more times for each other state...
        }

        private void HandleState2()
        {
            _messageCollector("Handling state 2");
        }

        private void HandleState1()
        {
            _messageCollector("Handling state 1");
        }
    }
}