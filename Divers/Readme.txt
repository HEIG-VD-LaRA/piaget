---
014.07.03
eliminate all the command "(FPiaget.ActiveForm != null)" because it will stop the program when focus on other windowform.
This is the method that applied to use for now but it can be another way to do also.
---

013.07.10 SL et JDZ

Problème de vitesse: si souris immobile, les TicksParSecondes chutent

---
013.07.04

Sleep now based only on system clicks
System clicks seem to be 100ns increments
But this number is not often updated!
So it is not suitable for very short SleepAGN instructions.

JDZ 013.07.04

Tests possible in BouclePrincipale
