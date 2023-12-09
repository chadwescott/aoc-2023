using AdventOfCode.Day_9;

namespace AdventOfCodeTests.Day_9
{
  [TestClass]
  public class OasisReportTests
  {
    private readonly OasisReport _target = new OasisReport();

    private readonly string _sampleData = @"0 3 6 9 12 15
1 3 6 10 15 21
10 13 16 21 30 45";

    private readonly string _inputData = @"22 46 86 149 248 414 728 1397 2912 6339 13806 29260 59578 116125 216860 389098 673042 1126204 1828838 2890511 4457940
9 18 38 79 153 275 477 848 1613 3271 6848 14421 30281 63488 133203 279148 580945 1192032 2396474 4700419 8974345
7 15 25 35 38 17 -60 -245 -615 -1277 -2373 -4085 -6640 -10315 -15442 -22413 -31685 -43785 -59315 -78957 -103478
12 20 43 103 225 431 739 1188 1926 3431 6998 15729 36417 82926 181942 382308 769560 1487750 2771173 4989203 8708081
23 26 36 64 134 295 636 1318 2646 5211 10135 19449 36623 67246 119821 206593 344265 554376 863014 1299414 1892844
12 16 39 90 188 375 729 1380 2542 4588 8225 14914 27913 54846 113740 246337 545596 1209188 2638127 5610294 11573486
11 11 9 5 14 78 291 864 2267 5502 12595 27460 57405 115760 226519 432802 813103 1514337 2821909 5310435 10164764
-8 -12 -16 -20 -24 -28 -32 -36 -40 -44 -48 -52 -56 -60 -64 -68 -72 -76 -80 -84 -88
10 13 16 22 45 123 347 919 2257 5173 11169 22937 45226 86369 160966 294518 531228 946757 1668478 2906744 5001915
23 53 112 218 398 704 1241 2220 4061 7583 14330 27094 50708 93194 167363 292976 499587 830201 1345892 2131538 3302842
-4 -3 -1 11 66 247 728 1829 4090 8385 16136 29788 53955 98204 183576 357063 721972 1498257 3136633 6525109 13348428
-2 -3 2 14 46 145 425 1124 2709 6064 12807 25793 49871 92974 167632 293009 497576 822543 1326184 2089200 3221276
25 41 69 116 194 332 596 1128 2222 4460 8945 17726 34696 67723 133827 271274 566131 1206923 2590569 5516960 11529754
6 3 -3 -2 27 116 308 657 1228 2097 3351 5088 7417 10458 14342 19211 25218 32527 41313 51762 64071
10 13 25 50 90 144 218 359 722 1673 3923 8684 17857 34341 62752 111274 196290 353525 664305 1316862 2747964
3 9 15 21 27 33 39 45 51 57 63 69 75 81 87 93 99 105 111 117 123
-8 3 34 103 251 558 1160 2260 4122 7043 11320 17273 25470 37488 58010 100241 199528 446817 1068460 2610231 6347029
20 29 40 56 97 213 501 1128 2360 4595 8396 14518 23921 37759 57333 83994 118980 163169 216728 278636 346057
-2 -3 9 45 120 272 587 1225 2442 4603 8181 13737 21876 33174 48071 66725 88822 113337 138241 160149 173904
13 26 55 124 272 553 1044 1882 3376 6278 12357 25523 53941 113959 237457 485823 976995 1938438 3811443 7455898 14548554
3 11 33 89 216 484 1027 2093 4114 7807 14361 25875 46433 84592 158687 307299 608565 1213803 2403233 4674421 8877438
8 19 30 41 52 63 74 85 96 107 118 129 140 151 162 173 184 195 206 217 228
21 47 96 177 295 442 580 617 381 -399 -2092 -5127 -9897 -16580 -24848 -33431 -39499 -37821 -19656 28673 127575
9 27 53 87 129 179 237 303 377 459 549 647 753 867 989 1119 1257 1403 1557 1719 1889
-2 -5 -7 -8 -8 -7 -5 -2 2 7 13 20 28 37 47 58 70 83 97 112 128
11 20 51 121 267 572 1206 2486 4976 9678 18405 34472 63884 117232 212518 379105 662913 1132840 1888159 3066307 4850017
-7 -5 -4 -9 -25 -57 -110 -189 -299 -445 -632 -865 -1149 -1489 -1890 -2357 -2895 -3509 -4204 -4985 -5857
-2 10 47 124 262 505 950 1803 3489 6857 13538 26560 51453 98382 186469 352607 669000 1276732 2447313 4690908 8939472
21 31 42 52 59 61 56 42 17 -21 -74 -144 -233 -343 -476 -634 -819 -1033 -1278 -1556 -1869
1 9 24 61 146 313 601 1051 1703 2593 3750 5193 6928 8945 11215 13687 16285 18905 21412 23637 25374
15 27 44 76 148 307 641 1332 2777 5839 12350 26096 54682 112907 228567 451924 870387 1630179 2966816 5245972 9015584
15 27 38 50 81 187 497 1270 2992 6544 13492 26581 50564 93596 169685 303415 539989 967825 1769642 3334724 6495291
12 17 25 36 50 67 87 110 136 165 197 232 270 311 355 402 452 505 561 620 682
22 45 89 165 291 495 820 1338 2196 3753 6936 14076 30758 69797 159662 362131 808823 1775638 3831896 8133960 16993246
10 5 -8 -24 -32 -8 113 511 1639 4516 11219 25651 54675 109717 208954 380216 664744 1121959 1835410 2920082 4531258
10 12 15 36 101 255 586 1263 2588 5062 9465 16950 29151 48305 77388 120265 181854 268304 387187 547704 760905
21 49 98 175 287 441 644 903 1225 1617 2086 2639 3283 4025 4872 5831 6909 8113 9450 10927 12551
20 26 31 38 53 85 146 251 418 668 1025 1516 2171 3023 4108 5465 7136 9166 11603 14498 17905
26 35 50 83 159 322 647 1283 2566 5255 10958 22829 46631 92274 175951 323009 571706 978019 1621682 2613647 4105175
6 2 9 50 175 470 1074 2221 4330 8185 15302 28702 54528 105280 205901 404527 790426 1522560 2873495 5295458 9518945
4 23 55 110 202 355 626 1151 2219 4378 8576 16339 29987 52888 89749 146942 232862 358313 536917 785540 1124728
13 22 44 93 187 348 605 1000 1597 2494 3838 5843 8811 13156 19431 28358 40861 58102 81520 112873 154283
20 27 46 97 203 385 669 1132 2028 4049 8790 19501 42223 87419 172225 323460 581548 1005519 1679270 2719281 4283995
2 6 15 34 75 169 397 946 2202 4914 10504 21669 43561 86143 169040 331834 656269 1314017 2667544 5477075 11311086
24 54 106 184 287 406 519 597 659 958 2452 7820 23417 62687 151567 336097 691382 1328506 2390798 4021184 6265551
-10 0 24 56 99 188 425 1026 2373 5055 9887 17941 30752 51169 86018 153277 299688 641162 1450474 3338518 7612673
1 14 47 114 233 425 713 1121 1673 2392 3299 4412 5745 7307 9101 11123 13361 15794 18391 21110 23897
24 48 82 126 180 244 318 402 496 600 714 838 972 1116 1270 1434 1608 1792 1986 2190 2404
10 11 14 26 71 206 544 1286 2760 5461 10091 17627 29530 48419 80012 138144 256673 515856 1097563 2395397 5225144
-3 -4 -6 -7 10 84 286 747 1729 3787 8128 17393 37302 79952 170106 356654 732717 1469834 2874662 5481117 10197562
16 25 34 43 52 61 70 79 88 97 106 115 124 133 142 151 160 169 178 187 196
3 11 36 90 183 315 478 681 1017 1811 3930 9408 22646 52598 116591 246888 502131 988111 1897228 3585778 6726429
6 17 46 114 261 554 1097 2057 3743 6817 12786 25029 50767 104624 214830 433820 856224 1649473 3106427 5737759 10439339
16 25 34 43 52 61 70 79 88 97 106 115 124 133 142 151 160 169 178 187 196
11 20 54 141 317 618 1070 1684 2471 3512 5166 8609 17142 39223 95189 231454 549000 1257712 2775209 5899435 12100816
21 31 51 97 202 425 860 1650 3017 5325 9198 15716 26694 44976 74484 119350 180669 247983 280089 165359 -355934
3 10 34 93 226 515 1132 2430 5112 10553 21429 42933 85038 166514 321765 612175 1144988 2105963 3819859 6870992 12356033
10 4 -5 -21 -44 -58 -18 159 604 1534 3381 7127 15030 32016 68124 142527 289814 569408 1079215 1974851 3496080
18 36 68 126 249 520 1093 2246 4494 8833 17246 33685 65846 128172 246646 466066 860622 1548718 2713100 4627468 7690875
19 24 23 28 72 229 643 1573 3471 7120 13876 26106 48043 87582 160184 297332 564425 1097602 2177733 4376764 8845284
13 19 26 43 97 258 686 1718 4032 8956 19033 39008 77470 149461 280455 512213 911135 1579857 2672980 4417969 7142423
10 24 38 52 66 80 94 108 122 136 150 164 178 192 206 220 234 248 262 276 290
17 32 57 95 157 265 455 780 1313 2150 3413 5253 7853 11431 16243 22586 30801 41276 54449 70811 90909
6 6 7 10 16 26 41 62 90 126 171 226 292 370 461 566 686 822 975 1146 1336
15 24 51 109 213 380 636 1036 1709 2961 5520 11108 23696 52048 114468 246950 516015 1037066 1997541 3680619 6478435
12 25 42 63 103 202 443 986 2126 4383 8632 16281 29505 51544 87073 142652 227264 352949 535542 795523 1158987
10 21 45 90 164 279 455 724 1134 1753 2673 4014 5928 8603 12267 17192 23698 32157 42997 56706 73836
13 17 39 94 211 441 874 1674 3136 5764 10364 18141 30784 50518 80097 122707 181743 260419 361165 484760 629145
5 9 20 52 123 260 519 1037 2141 4547 9690 20234 40819 79110 147221 263595 455429 761741 1237184 1956720 3021275
3 18 57 127 240 437 830 1668 3435 7002 13904 26935 51516 98807 192478 382665 773232 1572506 3184002 6364129 12492461
2 6 25 78 193 403 748 1290 2160 3678 6621 12781 26121 55249 118863 257746 560598 1217814 2629549 5616060 11816353
0 -1 -6 -3 26 100 234 434 692 981 1250 1419 1374 962 -14 -1800 -4696 -9061 -15318 -23959 -35550
-3 2 18 61 158 346 671 1187 1955 3042 4520 6465 8956 12074 15901 20519 26009 32450 39918 48485 58218
8 21 59 151 339 686 1295 2336 4083 6980 11797 20041 35028 64528 126864 264066 568554 1234395 2651171 5568851 11376993
9 26 54 97 167 297 563 1123 2282 4608 9176 18132 35980 72341 147459 302486 617623 1242590 2445714 4690235 8749317
-7 4 31 86 198 415 813 1537 2919 5752 11866 25283 54464 116548 245064 503401 1007349 1961232 3713433 6838264 12251850
1 -1 -9 -27 -62 -122 -210 -314 -393 -359 -55 771 2496 5656 10984 19452 32317 51171 77995 115217 165774
19 45 97 194 358 616 1010 1619 2598 4237 7037 11804 19830 33504 58483 110429 233245 543169 1325977 3235282 7670934
9 17 48 124 286 609 1236 2442 4735 9002 16718 30263 53453 92517 157993 268446 457633 787891 1374280 2426594 4320028
-3 -1 9 24 34 18 -56 -212 -407 -403 484 3883 13417 37023 92223 218121 502225 1138635 2549877 5633060 12241300
17 35 70 136 268 539 1076 2070 3774 6492 10598 16717 26402 44048 81581 169013 377001 863583 1969264 4408340 9650458
15 34 62 93 131 214 456 1126 2796 6603 14683 30848 61590 117509 215275 380247 649885 1078104 1740732 2742247 4223981
-6 -8 -5 10 48 133 334 848 2173 5426 12895 28985 61853 126263 248578 475405 888300 1628220 2935195 5211124 9116838
19 38 66 102 142 179 203 201 157 52 -136 -432 -864 -1463 -2263 -3301 -4617 -6254 -8258 -10678 -13566
5 12 45 130 313 664 1276 2259 3729 5792 8523 11940 15973 20428 24946 28957 31629 31812 27977 18150 -159
7 21 56 129 267 507 896 1491 2359 3577 5232 7421 10251 13839 18312 23807 30471 38461 47944 59097 72107
1 3 18 51 101 170 282 512 1025 2125 4314 8361 15381 26924 45074 72558 112865 170375 250498 359823 506277
2 5 1 -5 7 80 292 769 1697 3351 6224 11483 22255 46752 105164 243909 563768 1273489 2788855 5910731 12136635
3 16 41 83 147 238 361 521 723 972 1273 1631 2051 2538 3097 3733 4451 5256 6153 7147 8243
10 14 16 15 10 0 -16 -39 -70 -110 -160 -221 -294 -380 -480 -595 -726 -874 -1040 -1225 -1430
6 2 -2 -8 -9 35 242 898 2638 6809 16189 36372 78333 162974 328837 644668 1229142 2280828 4122400 7264200 12493547
23 36 48 59 69 78 86 93 99 104 108 111 113 114 114 113 111 108 104 99 93
3 7 20 54 128 270 517 913 1502 2310 3307 4337 5001 4475 1242 -7286 -25283 -59191 -118602 -217376 -375034
19 25 41 89 205 453 951 1909 3679 6817 12157 20897 34697 55789 87099 132381 196363 284905 405169 565801 777125
8 10 14 33 102 301 803 1958 4424 9356 18664 35351 63942 111015 185845 301172 474104 727166 1089506 1598269 2300150
-6 -7 -10 -16 -11 46 235 687 1596 3231 5948 10202 16559 25708 38473 55825 78894 108981 147570 196340 257177
10 27 66 148 300 546 900 1380 2080 3366 6321 13695 31908 75280 174939 397361 882292 1918924 4096556 8599011 17774622
11 16 24 38 65 120 237 493 1043 2148 4145 7254 11060 13514 9516 -10144 -57033 -134680 -207554 -126966 525423
17 20 32 68 155 347 749 1560 3160 6294 12459 24693 49115 97798 193942 381066 739664 1418982 2701681 5142310 9870976
12 28 61 132 270 520 962 1756 3243 6162 12095 24324 49365 99525 196936 379788 712263 1301680 2330806 4121872 7263405
18 41 83 152 256 403 601 858 1182 1581 2063 2636 3308 4087 4981 5998 7146 8433 9867 11456 13208
9 31 76 162 317 595 1110 2092 3975 7546 14220 26575 49423 91991 172402 326884 628541 1225029 2412620 4778300 9465337
6 11 24 56 129 281 568 1063 1852 3027 4676 6870 9647 12993 16820 20941 25042 28651 31104 31508 28701
8 7 9 20 48 102 188 314 540 1147 3051 8662 23516 59270 139203 308470 653384 1337415 2666865 5206616 9975824
14 30 63 118 209 366 645 1140 2004 3511 6239 11534 22539 46260 97450 205703 428566 876908 1766823 3530062 7051633
12 24 54 111 205 344 546 875 1504 2805 5469 10668 20280 37197 65731 112204 186232 304686 504312 878325 1671891
14 15 14 18 34 73 173 459 1265 3350 8247 18791 39879 79522 150256 270986 469344 784649 1271564 2004552 3083240
8 3 -4 -13 -24 -37 -52 -69 -88 -109 -132 -157 -184 -213 -244 -277 -312 -349 -388 -429 -472
16 23 32 54 112 258 600 1344 2875 5939 12053 24381 49522 101083 206812 422936 863094 1756507 3563682 7203068 14487352
3 8 26 76 203 500 1150 2498 5168 10261 19717 37007 68450 125635 229679 418379 757729 1359782 2409452 4203582 7206461
19 38 74 144 269 474 788 1244 1879 2734 3854 5288 7089 9314 12024 15284 19163 23734 29074 35264 42389
11 15 16 16 22 48 135 404 1157 3041 7290 16060 32872 63178 115065 200112 334415 539795 845204 1288344 1917514
21 42 66 101 179 368 784 1603 3073 5526 9390 15201 23615 35420 51548 73087 101293 137602 183642 241245 312459
10 35 81 166 318 577 1003 1695 2839 4826 8523 15876 31253 64440 137210 297218 646064 1393245 2955009 6127510 12377832
11 24 53 106 191 316 489 718 1011 1376 1821 2354 2983 3716 4561 5526 6619 7848 9221 10746 12431
18 26 35 50 78 133 250 513 1111 2456 5438 11978 26217 57023 123123 263233 555280 1151462 2339821 4648634 9017768
17 41 89 177 328 577 982 1646 2755 4637 7847 13283 22338 37093 60556 96952 152069 233665 351941 520085 754892
13 26 39 52 65 78 91 104 117 130 143 156 169 182 195 208 221 234 247 260 273
13 29 62 110 166 218 249 237 155 -29 -352 -856 -1588 -2600 -3949 -5697 -7911 -10663 -14030 -18094 -22942
7 5 3 1 -1 -3 -5 -7 -9 -11 -13 -15 -17 -19 -21 -23 -25 -27 -29 -31 -33
14 10 10 35 120 314 680 1295 2250 3650 5614 8275 11780 16290 21980 29039 37670 48090 60530 75235 92464
-4 -1 20 70 157 285 460 704 1069 1639 2530 3977 6786 13843 34269 93724 258298 687119 1743060 4216020 9755435
11 26 45 65 80 77 33 -74 -204 -78 1223 6069 19855 54050 132182 301736 657921 1390934 2878789 5866337 11802978
7 18 47 106 211 387 685 1240 2416 5105 11283 24994 54052 112946 227754 444433 842893 1561236 2838219 5088606 9037425
11 9 3 -8 -19 -2 125 545 1607 3911 8415 16566 30457 53012 88201 141287 219107 330389 486107 699876 988389
17 26 33 38 41 42 41 38 33 26 17 6 -7 -22 -39 -58 -79 -102 -127 -154 -183
28 38 52 75 112 171 281 539 1207 2890 6834 15384 32631 65249 123473 222092 381222 626478 987976 1497361 2181770
13 34 69 118 181 258 349 454 573 706 853 1014 1189 1378 1581 1798 2029 2274 2533 2806 3093
7 6 7 31 124 372 921 1999 3934 7166 12266 20008 31607 49368 78240 129214 226257 419686 810753 1594981 3135766
12 17 22 27 32 37 42 47 52 57 62 67 72 77 82 87 92 97 102 107 112
21 26 30 30 26 37 126 445 1335 3552 8738 20316 45060 95675 194818 381099 717721 1304550 2294550 3915674 6499470
5 2 -7 -16 -14 7 50 130 332 945 2725 7383 18516 43502 97540 212348 454635 964500 2033593 4261230 8860690
6 11 20 42 90 189 407 925 2159 4955 10926 23145 47751 97743 201651 422484 897498 1919017 4094614 8658154 18062950
3 7 16 48 146 402 1005 2334 5124 10752 21737 42640 81714 153947 286686 530079 976613 1797957 3314718 6128244 11367574
26 43 79 149 268 451 713 1069 1534 2123 2851 3733 4784 6019 7453 9101 10978 13099 15479 18133 21076
5 30 79 165 320 606 1121 1997 3385 5428 8257 12153 18282 30949 63280 149806 371835 905200 2105898 4659242 9836216
7 24 45 79 142 253 433 704 1079 1533 1954 2097 1609 267 -1315 -85 12611 56770 173543 441263 1000716
10 24 46 77 122 202 379 812 1876 4392 10034 21999 46048 92050 176187 324006 574534 985704 1641374 2660257 4207118
27 40 52 73 123 242 512 1096 2301 4686 9290 18205 36062 73685 156417 341731 754099 1650200 3535020 7359981 14848825
8 26 68 159 336 659 1246 2344 4450 8499 16135 30066 54456 95209 159893 257180 396787 594810 900010 1482198 2880673
4 6 22 65 148 284 486 767 1140 1618 2214 2941 3812 4840 6038 7419 8996 10782 12790 15033 17524
17 26 36 60 134 335 802 1758 3531 6581 11572 19617 33040 57471 107041 216243 465261 1031152 2286560 4982634 10576338
13 13 19 42 104 257 625 1480 3363 7261 14851 28822 53286 94289 160433 263620 419929 650637 983395 1453570 2105764
23 43 69 110 181 301 495 806 1335 2352 4559 9638 21304 47274 103019 219226 457261 942029 1932367 3971118 8200861
5 -2 -17 -33 -22 77 381 1117 2739 6148 13067 26660 52580 100833 189213 349670 639905 1163842 2106519 3791493 6772206
24 32 44 75 158 356 779 1605 3112 5749 10308 18314 32849 60212 113156 217025 421052 818506 1581440 3018649 5669252
3 3 17 71 201 459 925 1721 3023 5071 8191 12877 20048 31715 52521 93127 177687 360811 766805 1680059 3748095
-2 8 39 94 172 268 373 474 554 592 563 438 184 -236 -863 -1742 -2922 -4456 -6401 -8818 -11772
13 28 71 159 313 558 923 1441 2149 3088 4303 5843 7761 10114 12963 16373 20413 25156 30679 37063 44393
-1 14 50 123 253 455 725 1025 1275 1364 1196 791 465 1117 4655 14597 36887 80970 161174 298451 522533
7 13 37 100 228 456 838 1463 2477 4111 6715 10798 17074 26514 40404 60409 88643 127745 180961 252232 346288
3 7 15 38 100 238 502 955 1673 2745 4273 6372 9170 12808 17440 23233 30367 39035 49443 61810 76368
-10 -16 -15 9 84 253 585 1212 2420 4833 9741 19636 39034 75676 142217 258529 454762 775326 1283977 2070211 3257192
4 18 44 93 192 400 838 1733 3476 6694 12336 21773 36912 60324 95386 146437 218948 319706 457012 640893 883328
19 43 79 127 187 259 343 439 547 667 799 943 1099 1267 1447 1639 1843 2059 2287 2527 2779
-1 -7 -20 -43 -81 -130 -149 1 680 2696 7691 18754 41342 84603 163208 299812 528277 897803 1478126 2365955 3692833
19 32 45 58 71 84 97 110 123 136 149 162 175 188 201 214 227 240 253 266 279
-5 -9 -13 -17 -21 -25 -29 -33 -37 -41 -45 -49 -53 -57 -61 -65 -69 -73 -77 -81 -85
4 8 31 94 228 473 890 1610 2968 5805 12078 26021 56288 119857 249156 505297 1003364 1962178 3804149 7356424 14251908
20 30 41 59 86 122 178 314 728 1942 5162 12947 30456 67861 145238 302813 622698 1274816 2612505 5367349 11036408
21 38 80 163 317 609 1187 2355 4689 9204 17582 32471 57865 99575 165801 267815 420765 644610 965196 1415483 2036933
16 23 42 94 220 495 1042 2046 3768 6559 10874 17286 26500 39367 56898 80278 110880 150279 200266 262862 340332
10 15 37 88 179 316 508 807 1403 2805 6157 13773 30055 63178 128542 256600 511541 1035956 2154782 4608023 10050692
23 50 93 158 252 392 639 1180 2491 5632 12772 28153 59926 123692 249234 492923 959727 1840766 3475071 6447768 11741480
15 24 52 115 233 430 734 1177 1795 2628 3720 5119 6877 9050 11698 14885 18679 23152 28380 34443 41425
7 6 7 9 11 12 11 7 -1 -14 -33 -59 -93 -136 -189 -253 -329 -418 -521 -639 -773
9 26 50 81 119 164 216 275 341 414 494 581 675 776 884 999 1121 1250 1386 1529 1679
8 10 4 -13 -40 -71 -90 -55 136 704 2080 5035 10856 21575 40258 71361 121160 198262 314204 484147 727672
13 18 21 37 94 240 559 1208 2507 5148 10640 22173 46155 94731 189597 367323 686125 1233482 2133059 3547921 5674824
-3 -1 1 3 5 7 9 11 13 15 17 19 21 23 25 27 29 31 33 35 37
14 23 33 53 112 270 634 1397 2930 5974 12008 23917 47158 91729 175393 328803 603422 1083441 1903275 3272669 5511980
6 18 33 51 72 96 123 153 186 222 261 303 348 396 447 501 558 618 681 747 816
14 18 20 24 52 153 420 1038 2403 5389 11910 26038 56118 118640 245290 496075 984632 1928460 3749640 7275000 14125188
11 15 18 21 43 134 388 956 2059 4001 7182 12111 19419 29872 44384 64030 90059 123907 167210 221817 289803
7 12 27 64 143 301 611 1230 2509 5221 11005 23196 48325 98742 197053 383384 726907 1343602 2422903 4266704 7345203
-6 -3 18 81 227 532 1144 2344 4648 8990 17060 31916 59045 108115 195738 349653 614838 1062171 1800382 2992171 4875511
4 7 23 65 156 330 637 1164 2091 3824 7311 14797 31599 70154 158921 361217 813542 1800593 3896679 8222957 16899918
17 41 78 143 278 573 1208 2529 5172 10258 19704 36748 66911 119893 213462 381499 690475 1272603 2391210 4567009 8816972
23 28 37 64 141 330 739 1559 3150 6226 12241 24195 48327 97665 199395 409935 845292 1741302 3571578 7275598 14694476
10 32 64 114 206 400 839 1836 4014 8512 17270 33406 61698 109184 185893 305720 487458 756000 1143724 1692074 2453350
15 31 58 94 141 222 407 848 1823 3789 7444 13798 24253 40692 65577 102056 154079 226523 325326 457630 631933
11 20 30 49 94 187 351 606 965 1430 1988 2607 3232 3781 4141 4164 3663 2408 122 -3523 -8910
2 8 32 101 262 583 1158 2121 3666 6061 9650 14895 22696 35683 62144 126128 290634 706522 1709052 3998381 8962042
15 18 22 32 73 201 522 1233 2704 5639 11409 22775 45470 91581 186523 382879 786877 1607348 3243448 6437310 12532551
-2 -6 -12 -17 -4 83 389 1240 3298 7804 16938 34329 65752 120053 210347 355538 582214 926974 1439248 2184675 3249108
14 18 24 33 53 118 321 860 2096 4622 9342 17559 31071 52274 84271 130986 197282 289082 413492 578925 795225
18 36 67 116 188 292 451 718 1198 2076 3651 6376 10904 18140 29299 45970 70186 104500 152067 216732 303124
-10 -3 12 34 65 110 177 277 424 635 930 1332 1867 2564 3455 4575 5962 7657 9704 12150 15045
14 31 67 133 256 494 955 1818 3361 6024 10590 18691 34119 65995 135973 293706 648296 1429092 3097999 6549086 13452886
16 28 48 79 135 263 574 1280 2729 5420 9965 16945 26582 38119 48765 52022 35166 -24396 -164226 -443805 -953791
16 19 18 7 -26 -108 -300 -718 -1529 -2859 -4476 -4968 117 22116 86664 247187 608290 1364623 2863142 5699693 10864656
25 35 41 50 77 150 334 787 1864 4286 9386 19430 37987 70290 123496 206728 330783 507441 748443 1064462 1464821
5 10 28 73 173 386 843 1842 4027 8709 18448 38163 77358 154704 307486 610839 1216256 2427438 4847670 9662892 19179712
23 34 58 109 209 400 763 1452 2759 5238 9932 18767 35201 65244 118997 212894 372871 638730 1070014 1753761 2814561
10 25 56 107 182 285 420 591 802 1057 1360 1715 2126 2597 3132 3735 4410 5161 5992 6907 7910
2 8 19 34 48 61 103 282 863 2397 5955 13605 29432 61687 127122 259304 523804 1044754 2049511 3941248 7413428
0 4 11 26 62 146 332 730 1558 3224 6450 12459 23254 42016 73623 125227 206700 330548 510565 758024 1073542
12 9 8 13 25 47 106 294 825 2110 4887 10536 21894 45200 94285 198817 419354 873183 1776458 3510015 6718447
12 11 16 37 96 253 657 1628 3771 8130 16420 31436 57839 103680 183291 322643 569118 1009149 1799784 3224559 5791002
-6 -3 8 40 113 265 591 1334 3062 6986 15528 33366 69413 140622 279345 547608 1064842 2061635 3983080 7684620 14795905";

    [TestMethod]
    public void Part1Tests()
    {
      Assert.AreEqual(114, _target.CalculateReportValue(_sampleData, true));
      Assert.AreEqual(1798691765, _target.CalculateReportValue(_inputData, true));
    }

    [TestMethod]
    public void Part2Tests()
    {
      Assert.AreEqual(2, _target.CalculateReportValue(_sampleData, false));
      Assert.AreEqual(1104, _target.CalculateReportValue(_inputData, false));
    }

    [TestMethod]
    public void GetNormalValueTests()
    {
      var data = new List<List<long>>
      {
        new List<long>{ 10, 13, 16, 21, 30, 45 },
        new List<long>{ 3, 3, 5, 9, 15 },
        new List<long>{ 0, 2, 4, 6 },
        new List<long>{ 2, 2, 2 }
      };
      Assert.AreEqual(68, _target.GetNormalValue(data));
    }

    [TestMethod]
    public void GetBackwardsValueTests()
    {
      var data = new List<List<long>>
      {
        new List<long>{ 10, 13, 16, 21, 30, 45 },
        new List<long>{ 3, 3, 5, 9, 15 },
        new List<long>{ 0, 2, 4, 6 },
        new List<long>{ 2, 2, 2 }
      };
      Assert.AreEqual(5, _target.GetBackwardsValue(data));
    }
  }
}
