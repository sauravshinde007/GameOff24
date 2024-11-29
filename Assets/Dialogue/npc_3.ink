INCLUDE globals.ink

// Dialogue flow
{isTalked_NPC3 == false : -> main | -> already_chose}

=== main ===
You meet NPC3.
+ [Help NPC3]
    ~ isTalked_NPC3 = true
    ~ total_points += 10
    -> helped_npc1
+ [Ignore NPC3]
    ~ isTalked_NPC1 = true
    ~ total_points += -2
    -> ignored_npc1

=== helped_npc1 ===
You helped NPC3 and earned 10 points!
-> END

=== ignored_npc1 ===
You ignored NPC3. No points earned.
-> END

=== already_chose ===
You have already talked to me!
-> END