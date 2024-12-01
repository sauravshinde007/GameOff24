INCLUDE globals.ink

{isTalked_jack == false : -> main | -> already_chose}

=== main ===
You meet Jack at the café entrance.  
Jack: "Hey, you’re looking for Elysia, right? She was around here not long ago."  
+ [Press Jack for more details]  
    ~ isTalked_jack = true  
    ~ total_points += 3  
    -> jack_details  
+ [Ask if Jack knows why she left]  
    ~ isTalked_jack = true  
    ~ total_points += 5  
    -> jack_reasons  
+ [Say you’re just looking for someone and leave]  
    ~ isTalked_jack = true  
    ~ total_points += 0  
    -> ignored_jack  

=== jack_details ===
Jack: "She seemed on edge. I saw her drop this photo. Maybe it’ll help you figure things out."  
Clue Location: Café Booth Photo  
-> END  

=== jack_reasons ===
Jack: "I don’t know why she left, but she always said she was worried about someone following her. She left this photo behind, though."  
Clue Location: Café Booth Photo  
-> END  

=== ignored_jack ===
Jack: "Suit yourself. Hope you find her."  
-> END  

=== already_chose ===
Jack: "I told you everything I know. Check the photo if you haven’t already."  
-> END  
