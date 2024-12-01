INCLUDE globals.ink

{isTalked_mia == false : -> main | -> already_chose}

=== main ===
You meet Mia inside the nightclub.  
Mia: "Elysia was here not long ago. She looked like she was hiding from someone."  
+ [Ask Mia for more details about Elysia’s behavior]  
    ~ isTalked_mia = true  
    ~ total_points += 3  
    -> mia_behavior  
+ [Ask Mia if Elysia mentioned anything important]  
    ~ isTalked_mia = true  
    ~ total_points += 5  
    -> mia_clue  
+ [Brush Mia off and move on]  
    ~ isTalked_mia = true  
    ~ total_points += 0  
    -> ignored_mia  

=== mia_behavior ===
Mia: "She didn’t say much, but she left a note in the washroom. You should check there."  
Clue Location: Nightclub Washroom Letter  
-> END  

=== mia_clue ===
Mia: "She kept checking her phone. But she also left a note in the washroom. It might help."  
Clue Location: Nightclub Washroom Letter  
-> END  

=== ignored_mia ===
Mia: "If you’re not interested, I can’t help you."  
-> END  

=== already_chose ===
Mia: "I already told you to check the washroom!"  
-> END  
