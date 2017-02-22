
20 constant width
10 constant height
width height * constant area

variable screen
area cells allot

: xy ( x y -- i )
  width * swap + ;

: set-screen ( char i -- )
  cells screen + ! ;
: print-screen ( -- )
  page height 0 do  screen i width * + width cells type cr  loop ;

variable map
area cells allot

: set-map ( char i -- )  cells map + ! ;
: get-map ( i -- char )  cells map + @ ;
: fill-map ( char -- )
  area 0 do  dup i set-map  loop drop ;
: generate-test-map ( -- )
  area 0 do  i i set-map  loop ;
: map-to-screen
  area 0 do  i get-map  i set-screen  loop ;

46 fill-map
map-to-screen
print-screen

variable hero
