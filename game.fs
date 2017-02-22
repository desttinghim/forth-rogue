
\ Constants

20 constant width
10 constant height
width height * constant area

\ Variables

variable screen area cells allot
variable map area cells allot
variable hero 1 cells allot

\ Word definitions
\ General
: xy ( x y -- i )
  width * swap + ;
: i-to-xy ( TODO: make this ) ;
\ Screen
: set-screen ( char i -- )
  cells screen + ! ;
: print-screen ( -- )
  page height 0 do  width i * cells screen + width cells type cr  loop ;
\ Map
: set-map ( char i -- )  cells map + ! ;
: get-map ( i -- char )  cells map + @ ;
: fill-map ( char -- )
  area 0 do  dup i set-map  loop drop ;
: map-to-screen
  area 0 do  i get-map  i set-screen  loop ;
\ Hero
: place-hero ( i -- )
  hero 1 cells + ! ;
: locate-hero ( -- i )
  hero 1 cells + @ ;
: move-hero ( delta-x delta-y -- )
  xy locate-hero + place-hero ;
: hero-to-screen ( -- )
  64 locate-hero set-screen ;

: draw
  map-to-screen
  hero-to-screen
  print-screen ;
\ Runtime code

46 fill-map
9 4 xy place-hero
draw
