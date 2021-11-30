import React from 'react';
import './App.css';
import Unity, {UnityContext} from "react-unity-webgl";
import Wallet from "./components/Wallet/Wallet";

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
        {/*<Wallet/>*/}
        <Unity
            unityContext={unityContext}
            matchWebGLToCanvasSize={false}
            style={{ width: "100%", height: "100%" }}
            devicePixelRatio={1920/1080}
        />
    </>
    );

}

export default App;
