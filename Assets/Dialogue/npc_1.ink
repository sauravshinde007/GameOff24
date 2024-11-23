INCLUDE globals.ink

// Dialogue flow
{isTalked_NPC1 == false : -> main | -> already_chose}

=== main ===
You meet NPC1.
+ [Help NPC1]
    ~ isTalked_NPC1 = true
    ~ total_points += 10
    -> helped_npc1
+ [Ignore NPC1]
    ~ isTalked_NPC1 = true
    ~ total_points += 0
    -> ignored_npc1

=== helped_npc1 ===
You helped NPC1 and earned 10 points!
-> END

=== ignored_npc1 ===
You ignored NPC1. No points earned.
-> END

=== already_chose ===
You have already talked to me!
-> END
