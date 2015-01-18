using System;

using Bau.Libraries.LibTwitter.Core;

namespace Bau.Libraries.LibTwitter.Commands
{
	/// <summary>
	///		Comandos de <see cref="Trend"/>
	/// </summary>
	public class TrendCommands : BaseCommands
	{
		public TrendCommands(TwitterAccount objAccount) : base(objAccount) {}
		
		/// <summary>
		///		Carga las tendencias
		/// </summary>
		public TrendsCollection Load()
		{ return Parser.TrendParser.ParseCollection(base.GetResponse("http://api.twitter.com/1/trends/current.json", 
																																 false));
		}
		
		///// <summary>
		/////		Carga los datos de un mensaje de estado concreto
		///// </summary>
		//public  Load(long lngID)
		//{ // Añade los parámetros
		//    base.Parameters.Add("status", strStatus);
		//    base.Parameters.Add("in_reply_to_status_id", lngIDReplyTo);
		//    base.Parameters.Add("lat", dblLatitude);
		//    base.Parameters.Add("long", dblLongitude);
		//    base.Parameters.Add("place_id", dblPlaceID);
		//    base.Parameters.Add("display_coordinates", blnDisplayCoordinates);
		//    base.Parameters.Add("trim_user", blnTrimUser);
		//    base.Parameters.Add("include_entities", blnIncludeEntities);					
		//  // Envía el mensaje
		//    base.GetResponse("http://api.twitter.com/1/statuses/update.xml", true);
		//}
	
/*

Returns the top ten topics that are currently trending on Twitter. The response includes the time of the request, the name of each trend, and the url to the Twitter Search results page for that topic.
URL

http://api.twitter.com/1/trends.format
Supported formats

json
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Example requests
JSON
Try it! » twurl /1/trends.json

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18

	

{
  "trends": [
    {
      "name": "Guille Franco",
      "url": "http://search.twitter.com/search?q=Guille+Franco"
    },
    {
      "name": "#honestyhour",
      "url": "http://search.twitter.com/search?q=%23honestyhour"
    },
    ...
    {
      "name": "Vuvuzela",
      "url": "http://search.twitter.com/search?q=Vuvuzela"
    }
  ],
  "as_of": "Tue, 22 Jun 2010 17:19:03 +0000"
}

-------------



Returns the current top 10 trending topics on Twitter. The response includes the time of the request, the name of each trending topic, and query used on Twitter Search results page for that topic.
URL

http://api.twitter.com/1/trends/current.format
Supported formats

json
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Parameters
Optional

    * exclude Setting this equal to hashtags will remove all hashtags from the trends list.
          o http://api.twitter.com/1/trends/current.json?exclude=hashtags

----------------------



Returns the top 20 trending topics for each hour in a given day.
URL

http://api.twitter.com/1/trends/daily.format
Supported formats

json
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Parameters
Optional

    * date The start date for the report. The date should be formatted YYYY-MM-DD. A 404 error will be thrown if the date is older than the available search index (7-10 days). Dates in the future will be forced to the current date.
          o http://api.twitter.com/1/trends/daily.json?date=2010-06-20
    * exclude Setting this equal to hashtags will remove all hashtags from the trends list.
          o http://api.twitter.com/1/trends/daily.json?exclude=hashtags

Example requests
JSON
Try it! » twurl /1/trends/daily.json

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47
48
49
50
51
52
53
54
55
56
57
58
59
60
61
62
63
64
65
66
67
68
69
70
71
72
73
74
75
76
77
78
79
80
81
82
83
84
85
86
87
88
89
90
91
92
93
94
95
96
97
98
99
100
101
102
103
104
105
106
107
108
109
110
111
112
113
114
115
116
117
118
119
120
121
122
123
124
125
126
127
128
129
130
131
132
133
134
135
136
137
138
139
140
141
142
143
144
145
146
147
148
149
150
151
152
153
154
155
156
157
158
159
160
161
162
163
164
165
166
167
168
169
170
171
172
173
174
175
176
177
178
179
180
181
182
183
184
185
186
187
188
189
190
191
192
193
194
195
196
197
198
199
200
201
202
203
204
205
206
207
208
209
210
211
212
213
214
215
216
217
218
219
220
221
222
223
224
225
226
227
228
229
230
231
232
233
234
235
236
237
238
239
240
241
242
243
244
245
246
247
248
249
250
251
252
253
254
255
256
257
258
259
260
261
262
263
264
265
266
267
268
269
270
271
272
273
274
275
276
277
278
279
280
281
282
283
284
285
286
287
288
289
290
291
292
293
294
295
296
297
298
299
300
301
302
303
304
305
306
307
308
309
310
311
312
313
314
315
316
317
318
319
320
321
322
323
324
325
326
327
328
329
330
331
332
333
334
335
336
337
338
339
340
341
342
343
344
345
346
347
348
349
350
351
352
353
354
355
356
357
358
359
360
361
362
363
364
365

	

{
  "trends": {
    "2010-06-22 17:20": [
      {
        "name": "Guille Franco",
        "query": "Guille Franco"
      },
      {
        "name": "#worldcup",
        "query": "#worldcup"
      },
      ...
      {
        "name": "Uruguai",
        "query": "Uruguai"
      }
    ],
    "2010-06-22 06:20": [
      {
        "name": "#honestyhour",
        "query": "#honestyhour"
      },
      {
        "name": "#blackpeoplerules",
        "query": "#blackpeoplerules"
      },
      ...
      {
        "name": "Spain",
        "query": "Spain"
      }
    ],
    "2010-06-22 14:20": [
      {
        "name": "NAZRIL IRHAM",
        "query": "NAZRIL IRHAM"
      },
      {
        "name": "#worldcup",
        "query": "#worldcup"
      },
      ...
      {
        "name": "Domenech",
        "query": "Domenech"
      }
    ],
    "2010-06-22 15:20": [
      {
        "name": "NAZRIL IRHAM",
        "query": "NAZRIL IRHAM"
      },
      {
        "name": "Zuid Afrika",
        "query": "Zuid Afrika"
      },
      ...
      {
        "name": "iOS",
        "query": "iOS"
      }
    ],
    "2010-06-22 03:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Uruguay",
        "query": "Uruguay"
      }
    ],
    "2010-06-21 22:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "iBooks",
        "query": "iBooks"
      }
    ],
    "2010-06-22 04:20": [
      {
        "name": "CALA BOCA TADEU",
        "query": "CALA BOCA TADEU"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Bachelorette",
        "query": "Bachelorette"
      }
    ],
    "2010-06-22 02:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Galvu00e3o",
        "query": "Galvu00e3o"
      }
    ],
    "2010-06-22 00:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Uruguay",
        "query": "Uruguay"
      }
    ],
    "2010-06-21 23:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Govan",
        "query": "Govan"
      }
    ],
    "2010-06-21 21:20": [
      {
        "name": "CALA BOCA TADEU SCHMIDT",
        "query": "CALA BOCA TADEU SCHMIDT"
      },
      {
        "name": "Summer Solstice",
        "query": "Summer Solstice"
      },
      ...
      {
        "name": "Suiza",
        "query": "Suiza"
      }
    ],
-------------



Returns the top 30 trending topics for each day in a given week.
URL

http://api.twitter.com/1/trends/weekly.format
Supported formats

json
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Parameters
Optional

    * date The start date for the report. The date should be formatted YYYY-MM-DD. A 404 error will be thrown if the date is older than the available search index (3-4 weeks). Dates in the future will be forced to the current date.
          o http://api.twitter.com/1/trends/weekly.json?date=2010-06-20
    * exclude Setting this equal to hashtags will remove all hashtags from the trends list.
          o http://api.twitter.com/1/trends/weekly.json?exclude=hashtags

------------------



Returns the locations that Twitter has trending topic information for.

The response is an array of "locations" that encode the location's WOEID and some other human-readable information such as a canonical name and country the location belongs in.

A WOEID is a Yahoo! Where On Earth ID.
URL

http://api.twitter.com/1/trends/available.format
Supported formats

json, xml
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Parameters
Optional

    * lat If provided with a long parameter the available trend locations will be sorted by distance, nearest to furthest, to the co-ordinate pair. The valid ranges for longitude is -180.0 to +180.0 (East is positive) inclusive.
          o http://api.twitter.com/1/trends/available.json?lat=37.781157
    * long If provided with a lat parameter the available trend locations will be sorted by distance, nearest to furthest, to the co-ordinate pair. The valid ranges for longitude is -180.0 to +180.0 (East is positive) inclusive.
          o http://api.twitter.com/1/trends/available.json?long=-122.400612831116

Example requests
XML
Try it! » twurl /1/trends/available.json

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25

	

<?xml version="1.0" encoding="UTF-8"?>
<locations type="array">
  <location>
    <woeid>23424803</woeid>
    <name>Ireland</name>
    <placeTypeName code="12">Country</placeTypeName>
    <country type="Country" code="IE">Ireland</country>
    <url>http://where.yahooapis.com/v1/place/23424803</url>
  </location>
  <location>
    <woeid>23424975</woeid>
    <name>United Kingdom</name>
    <placeTypeName code="12">Country</placeTypeName>
    <country type="Country" code="GB">United Kingdom</country>
    <url>http://where.yahooapis.com/v1/place/23424975</url>
  </location>
  ...
  <location>
    <woeid>44418</woeid>
    <name>London</name>
    <placeTypeName code="7">Town</placeTypeName>
    <country type="Country" code="GB">United Kingdom</country>
    <url>http://where.yahooapis.com/v1/place/44418</url>
  </location>
</locations>

------------------------



Returns the top 10 trending topics for a specific WOEID, if trending information is available for it.

The response is an array of "trend" objects that encode the name of the trending topic, the query parameter that can be used to search for the topic on Twitter Search, and the Twitter Search URL.

This information is cached for 5 minutes. Requesting more frequently than that will not return any more data, and will count against your rate limit usage.
URL

http://api.twitter.com/1/trends/:woeid.format
Supported formats

json, xml
Supported request methods

GET
Requires Authentication

false About authentication »
Rate Limited

true About rate limiting »
Parameters
Required

    * woeid The Yahoo! Where On Earth ID of the location to return trending information for. Global information is available by using 1 as the WOEID.
          o http://api.twitter.com/1/trends/1.json

Example requests
XML
Try it! » twurl /1/trends/:woeid.json

1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21

	

<?xml version="1.0" encoding="UTF-8"?>
<matching_trends type="array">
<trends as_of="2010-07-15T22:39:53Z" created_at="2010-07-15T22:31:11Z">
  <locations>
    <location>
      <woeid>1</woeid>
      <name>Worldwide</name>
    </location>
  </locations>
  <trend query="Premios+Juventud" url="http://search.twitter.com/search?q=Premios+Juventud">Premios Juventud</trend>
  <trend query="%23agoodrelationship" url="http://search.twitter.com/search?q=%23agoodrelationship">#agoodrelationship</trend>
  <trend query="%23thistweetisdedicated2" url="http://search.twitter.com/search?q=%23thistweetisdedicated2">#thistweetisdedicated2</trend>
  <trend query="%23bb11" url="http://search.twitter.com/search?q=%23bb11">#bb11</trend>
  <trend query="Oil+Spill" url="http://search.twitter.com/search?q=Oil+Spill">Oil Spill</trend>
  <trend query="Inception" url="http://search.twitter.com/search?q=Inception">Inception</trend>
  <trend query="iOS" url="http://search.twitter.com/search?q=iOS">iOS</trend>
  <trend query="Goldman" url="http://search.twitter.com/search?q=Goldman">Goldman</trend>
  <trend query="AnahiPremiosJuventud" url="http://search.twitter.com/search?q=AnahiPremiosJuventud">AnahiPremiosJuventud</trend>
  <trend query="DulceMariaLivePJ" url="http://search.twitter.com/search?q=DulceMariaLivePJ">DulceMariaLivePJ</trend>
</trends>
</matching_trends>

-----------------------
*/

	}
}
