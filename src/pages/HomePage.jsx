import React, {useEffect, useState} from 'react';




const Home = () => {
    const [user, setUser] = useState([]);
    useEffect(() => {
        (
            async () => {
                const response = await fetch('http://localhost:5169/api/Authificate/User', {
                    headers: {'Content-Type': 'application/json'},
                    credentials: 'include',

                });

                const content = await response.json();
                setUser(content);
            console.log('1')
            }
        )();

    },[])
    let Home
    if(user.name != undefined){
        Home = (<div>{'hi'+ user.name + user.email}</div>)


    }
    else{
        Home =
            (<div>
                You are not logged in
            </div>)
    }
    return (
        Home
    );
};

export default Home;
