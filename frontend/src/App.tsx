import React from 'react';
import './App.css';
import Unity, {UnityContext} from "react-unity-webgl";
import GameContainer from './components/container/GameContainer';
import SDWalletProvider from './providers/wallet_provider';
import { WalletConnectButton, WalletDisconnectButton } from '@solana/wallet-adapter-react-ui';
import SDWalletConnectButtonView from './components/Wallet/WalletConnectButton';
import { WalletContext } from '@solana/wallet-adapter-react';
import SDButton from './components/button/Button';
import SDNavbar from './components/Navbar';

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
            <WalletContext.Consumer >
                {walletContext => <GameContainer
                        game={<Unity
                            unityContext={unityContext}
                            style={{ width: "100vw", height: "100vh" }} />}
                        sidebar={<div></div>}
                        navbar={
                            <SDNavbar>
                                {walletContext.connected && <WalletDisconnectButton />},
                                <SDWalletConnectButtonView />,
                                {walletContext.connected && 
                                    <SDButton onClick={() => {}}>Items</SDButton>
                                },
                            </SDNavbar>
                        } 
                    />}
            </WalletContext.Consumer>,
        </SDWalletProvider>
    </>
    );

}

export default App;
