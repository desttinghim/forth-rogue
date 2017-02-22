
40 constant width
10 constant height
width height * constant area

variable screen
area cells allot


: i-to-xy ( n -- x y )
  dup dup width mod swap height / ;
: xy-to-i ( x y -- n )
  width * swap + ;

: set-screen ( char x y -- )
  xy-to-i cells screen + ! ;
: print-screen ( -- )
  page height 0 do screen i width * + width cells type cr loop ;
\ : fill-screen ( char -- )
\  area 0 do dup i i-to-xy set-screen loop drop ;

\ 46 fill-screen


variable map
area cells allot

: set-map ( char x y -- )
  width * swap + cells screen + ! ;
: get-map ( x y -- char )
  xy-to-i cells map + @ ;
: fill-map ( -- )
  area 0 do dup i i-to-xy set-map loop drop ;
: map-to-screen
  area 0 do  i i-to-xy get-map i i-to-xy .s set-screen  loop ;

46 fill-map map-to-screen
print-screen

variable hero

.s
