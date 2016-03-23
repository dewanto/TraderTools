# TraderTools
Market trading analysis in C#.

## Simulator
The basic idea is to program a trader object with a given strategy, attach it to a market dataset, and have it place buy/sell
orders accordingly over a period of time. The functionality should include, at the minimum:

* Buy/sell market and limit orders (with stuff like take profit and stop loss levels, of course)
* Analysis on multiple timeframes (1-minute to monthly)

## Interface
The user should be able to program a trader via a simple API, with access to indicators (existing or custom-made), etc. Other
potential features might be:

* (Real-time?) Chart visualization
* ...