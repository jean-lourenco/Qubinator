# Qubinator
Qubinator is a [Nuget Package](https://www.nuget.org/packages/Qubinator) that can transform any string in all sorts of 'text cubes' you can imagine.

``` csharp
  using Qubinator;
```

**There are 4 main functions to use right now:**

## Simple 2D

``` csharp
  Quber.To2DSimple("INCONSTITUCIONAL");
  
  INCONSTITUCIONAL
  N               
  C               
  O               
  N               
  S               
  T               
  I               
  T               
  U               
  C               
  I               
  O               
  N               
  A               
  L                

```


## Full 2D

``` csharp
  Quber.To2DFull("INCONSTITUCIONAL");
  
  INCONSTITUCIONAL
  N              A
  C              N
  O              O
  N              I
  S              C
  T              U
  I              T
  T              I
  U              T
  C              S
  I              N
  O              O
  N              C
  A              N
  LANOICUTITSNOCNI


```


## 3D

This one is especially nice with long words:
``` csharp
  Quber.To3D("INCONSTITUCIONAL");
  
  INCONSTITUCIONAL       
  N\             A\      
  C \            N \     
  O  \           O  \    
  N   \          I   \   
  S    \         C    \  
  T     \        U     \ 
  I      INCONSTITUCIONAL
  T      N       I      A
  U      C       T      N
  C      O       S      O
  I      N       N      I
  O      S       O      C
  N      T       C      U
  A      I       N      T
  LANOICUTITSNOCNI      I
   \     U        \     T
    \    C         \    S
     \   I          \   N
      \  O           \  O
       \ N            \ C
        \A             \N
         LANOICUTITSNOCNI

```

## Full Offsetted Text

``` csharp
  Quber.ToFullTextOffset("INCONSTITUCIONAL");
  
INCONSTITUCIONAL
NCONSTITUCIONALI
CONSTITUCIONALIN
ONSTITUCIONALINC
NSTITUCIONALINCO
STITUCIONALINCON
TITUCIONALINCONS
ITUCIONALINCONST
TUCIONALINCONSTI
UCIONALINCONSTIT
CIONALINCONSTITU
IONALINCONSTITUC
ONALINCONSTITUCI
NALINCONSTITUCIO
ALINCONSTITUCION
LINCONSTITUCIONA

```
