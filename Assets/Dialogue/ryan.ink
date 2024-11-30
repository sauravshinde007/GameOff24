INCLUDE globals.ink

{isTalked_ryan == false : -> main_ryan | -> already_chose_ryan}

=== main_ryan ===  
You meet Ryan, a bouncer guarding the nightclub VIP entrance.  

+ [“Because she’s in danger, Ryan. Help me.”]  
    ~ isTalked_ryan = true  
    ~ total_points += 2  
    -> persuaded_ryan  

+ [“Just give me something useful, Ryan.”]  
    ~ isTalked_ryan = true  
    ~ total_points -= 1  
    -> intimidated_ryan  

=== persuaded_ryan ===  
Ryan: "Alright. She left this photo with a friend. Here, take it."  
+1 Clue (Photo) earned!  

Photo Description: *A group photo of Elysia, Emma, and a stranger in front of Elysia’s apartment.*  
-> END  

=== intimidated_ryan ===  
Ryan: "Fuck you."  

-> END  

=== already_chose_ryan ===  
Ryan: "I told you, I’ve got nothing else."  
-> END  
