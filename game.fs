
\ Constants

100 constant width
40 constant height
width height * constant area
46 constant empty

\ Variables

variable screen area cells allot
variable map area cells allot
variable hero 1 cells allot
variable quit
false quit !

\ Word definitions
\ General
: quit-game ( -- )  true quit ! ;
: quit ( -- quit ) quit @ ;
: xy ( x y -- i )  width * swap + ;
: i-to-xy ( TODO: make this ) ;

\ Screen
: set-screen ( char i -- )  cells screen + ! ;
: print-screen ( -- )
  page height 0 do  width i * cells screen + width cells type cr  loop ;

\ Map
: set-map ( char i -- )  cells map + ! ;
: get-map ( i -- char )  cells map + @ ;
: fill-map ( char -- )  area 0 do  dup i set-map  loop drop ;
: map-to-screen ( -- )  area 0 do  i get-map  i set-screen  loop ;

\ Hero
: place-hero ( i -- )   hero 1 cells + ! ;
: locate-hero ( -- i )  hero 1 cells + @ ;
: move-hero ( delta-x delta-y -- )
  xy locate-hero +
  dup 0 > if dup area < if
  dup get-map empty = if place-hero else drop then then then ;
: hero-to-screen ( -- )  64 locate-hero set-screen ;

\ Control
: input ( -- )
  key dup 119 = if  0 -1 move-hero  else
      dup 97  = if -1  0 move-hero  else
      dup 115 = if  0  1 move-hero  else
      dup 100 = if  1  0 move-hero  else
      dup 113 = if  quit-game  then
  then then then then drop ;
: draw ( -- ) map-to-screen  hero-to-screen  print-screen ;
: gameloop ( -- ) begin input draw  quit until ;
: init ( -- )
  empty fill-map
  9 4 xy place-hero
  draw
  gameloop ;

init
