INCLUDE globals.ink

{isTalked_NPC2 == false : -> main | -> already_chose}

=== main ===
You meet NPC2.
+ [Solve NPC2's problem]
    ~ isTalked_NPC2 = true
    ~ total_points += 15
    -> solved_problem
+ [Refuse to help NPC2]
    ~ isTalked_NPC2 = true
    ~ total_points += -5
    -> refused_help

=== solved_problem ===
You solved NPC2's problem and earned 15 points!
-> END

=== refused_help ===
You refused to help NPC2 and lost 5 points.
-> END

=== already_chose ===
You have already talked to bro!
-> END