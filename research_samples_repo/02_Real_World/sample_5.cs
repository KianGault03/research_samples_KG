// ============================================================================
// Date Retrieved:      2025-06-10
// Source:              Stack Overflow question “Multithreading puzzle, why is there a race condition?” (ID 65862577)
// URL:                 https://stackoverflow.com/questions/65862577/multithreading-puzzle-why-is-there-a-race-condition
// Author:              Marc Cayuela (OP) and contributors (CC BY-SA 4.0)
// Description:         Demonstrates a custom lock implementation 
// ============================================================================
using System;
using System.Threading;
using System.Threading.Tasks;

namespace research_samples_repo.Real_World
{
    public class Sample_5
    {
        public class DoActionLock
        {
            private readonly object _lock = new object();
            private bool _isLocked;

            public void DoAfterAcquiringLock(Action action)
            {
                // wait till we have the lock
                while (TryAcquireLock())
                    Thread.Sleep(20);
                try
                {
                    action.Invoke();
                }
                finally
                {
                    ReleaseLock();
                }
            }

            public bool TryAcquireLock()
            {
                lock (_lock)
                {
                    if (_isLocked)
                        return false;
                    _isLocked = true;
                }
                return true;
            }

            public void ReleaseLock()
            {
                lock (_lock)
                    _isLocked = false;
            }
        }

        

    }
}
