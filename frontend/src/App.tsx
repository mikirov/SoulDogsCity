import React from 'react';
import './App.css';
import Unity, {UnityContext} from "react-unity-webgl";
import GameContainer from './components/container/GameContainer';
import SDWalletProvider from './providers/wallet_provider';
import { WalletConnectButton } from '@solana/wallet-adapter-react-ui';
import SDWalletConnectButtonView from './components/Wallet/WalletConnectButton';

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
        <SDWalletProvider>
            <GameContainer 
                    game={<Unity
                        unityContext={unityContext}
                        style={{ width: "100vw", height: "100vh" }} />}
                    sidebar={<div></div>} 
                    actions={<SDWalletConnectButtonView></SDWalletConnectButtonView>}        />
        </SDWalletProvider>
    </>
    );

}

export default App;
