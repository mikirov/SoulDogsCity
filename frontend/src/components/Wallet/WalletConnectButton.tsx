import { WalletMultiButton } from '@solana/wallet-adapter-react-ui';
import { FC } from 'react';

// Default styles that can be overridden by your app
require('@solana/wallet-adapter-react-ui/styles.css');

const SDWalletConnectButton: FC = () => {
    // Can be set to 'devnet', 'testnet', or 'mainnet-beta'

    return (
        <WalletMultiButton />
    );
};

export default SDWalletConnectButton;
