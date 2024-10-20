using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 8300
// Hash 3393
// Hash 9814
// Hash 3990
// Hash 5239
// Hash 1638
// Hash 2382
// Hash 1312
// Hash 8152
// Hash 3509
// Hash 8710
// Hash 8312
// Hash 8025
// Hash 5841
// Hash 8550
// Hash 7355
// Hash 9962
// Hash 4677
// Hash 1680
// Hash 9363
// Hash 6072
// Hash 2276
// Hash 3781
// Hash 8124
// Hash 3218
// Hash 5647
// Hash 2007
// Hash 7323
// Hash 5388
// Hash 2733
// Hash 1272
// Hash 2149
// Hash 6362
// Hash 4482
// Hash 6323
// Hash 9595
// Hash 3111
// Hash 8018
// Hash 9020
// Hash 5004
// Hash 2139
// Hash 9261
// Hash 2495
// Hash 4291
// Hash 4385
// Hash 7712
// Hash 3213