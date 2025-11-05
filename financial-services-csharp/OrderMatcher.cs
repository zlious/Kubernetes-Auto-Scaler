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
// Hash 4375
// Hash 4592
// Hash 9888
// Hash 9646
// Hash 5371
// Hash 8625
// Hash 5926
// Hash 7926
// Hash 6561
// Hash 9044
// Hash 1355
// Hash 1956
// Hash 1250
// Hash 2167
// Hash 3071
// Hash 7674
// Hash 2930
// Hash 9156
// Hash 8810
// Hash 7076
// Hash 3241
// Hash 9495
// Hash 5073
// Hash 3599
// Hash 2124
// Hash 1389
// Hash 2789
// Hash 2734
// Hash 6436
// Hash 7937
// Hash 7843
// Hash 5791
// Hash 5669
// Hash 8632
// Hash 9743
// Hash 4339
// Hash 6475
// Hash 6325
// Hash 3432
// Hash 3616
// Hash 9958
// Hash 5754
// Hash 6897
// Hash 3861
// Hash 7461
// Hash 1356
// Hash 3289
// Hash 6784
// Hash 6198
// Hash 4502
// Hash 7555
// Hash 5251
// Hash 3635
// Hash 7529
// Hash 9276
// Hash 8942
// Hash 9211
// Hash 6783
// Hash 6061
// Hash 6920
// Hash 2561
// Hash 8949
// Hash 9654
// Hash 4193
// Hash 8034
// Hash 4240
// Hash 9597
// Hash 8210
// Hash 8039
// Hash 5012
// Hash 6449
// Hash 3862
// Hash 8052
// Hash 4549
// Hash 9071
// Hash 1831
// Hash 6930
// Hash 8774
// Hash 7565
// Hash 6240
// Hash 1865
// Hash 2382
// Hash 6198
// Hash 8752
// Hash 8687
// Hash 4838
// Hash 2497
// Hash 6679
// Hash 4260
// Hash 9221
// Hash 8847
// Hash 4593
// Hash 6552
// Hash 6471
// Hash 3892
// Hash 9639
// Hash 5571
// Hash 7880
// Hash 7191
// Hash 4893
// Hash 1544
// Hash 1641
// Hash 5583
// Hash 9926
// Hash 3287
// Hash 5566
// Hash 2275
// Hash 8823
// Hash 2860
// Hash 7766
// Hash 8354