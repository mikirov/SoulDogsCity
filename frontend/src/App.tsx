import React from 'react';
import './App.css';
import Unity, {UnityContext} from "react-unity-webgl";
import Wallet from "./components/Wallet/Wallet";
import GameContainer from './components/container/GameContainer';
import SideBar from './components/sidebar/SideBar';

const unityContext = new UnityContext({
    loaderUrl: "Build/Build.loader.js",
    dataUrl: "Build/Build.data",
    frameworkUrl: "Build/Build.framework.js",
    codeUrl: "Build/Build.wasm",
    companyName: "SoulDogs",
    productName: "SoulDogsCity",
    productVersion: "0.1",
});

function App() {
    return (
    <>
        <GameContainer game={
            <Unity
                unityContext={unityContext}
                style={{ width: "100vw", height: "100vh" }}
            /> 
        }
            sidebar={<SideBar />}
        />
        {/* <Wallet/> */}
    </>
    );

}

export default App;
