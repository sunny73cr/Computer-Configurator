import React, { useState, useCallback, createContext, useContext, useEffect } from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { AxiosError } from "axios";

import "./index.css";
import "./overlayFade.css";
import "./Modal.css";

/* Components */
import Header from "./Components/Header/Header";
import Loading from "./Components/Loading/Loading";

/* Pages */
import Home from "./Pages/Home";
import About from "./Pages/About";
import PartManagement from "./Pages/PartManagement/PartManagement";
import ConfigureComputer from "./Pages/ConfigureComputer";

import { ErrorWithoutResponse, ErrorWithResponse, StatusCode } from "./Services/AxiosBase.service";

import { aboutLink, configureComputerLink, homeLink, partSearchLink } from "./index";

//https://jamiehaywood.medium.com/typesafe-global-state-with-typescript-react-react-context-c2df743f3ce

interface ModalState {
	message: string;
	shown: boolean;
}

const defaultModalState: ModalState = {
	message: "",
	shown: false
};

const ModalContext = createContext({
	modalState: {} as ModalState,
	setModalState: {} as React.Dispatch<React.SetStateAction<ModalState>>
});

const AuthenticationSentinel = createContext({
	userId: {} as string | undefined,
	setUserId: {} as React.Dispatch<React.SetStateAction<string | undefined>>
});

export default function App() {
	const [modalState, setModalState] = useState<ModalState>(defaultModalState);
	const [userId, setUserId] = useState<string | undefined>(undefined);
	const [initialised, setInitialised] = useState<boolean>(false);

	useEffect(() => {
		try {
			//TODO: Authentication
			//let Id = CheckLoggedIn();
			//setUserId(Id);
			setInitialised(true);
		} catch (error) {
			let axiosError = error as AxiosError;
			if (axiosError.response) {
				switch (axiosError.response.status) {
					case StatusCode.Unauthorized:
						//allow an unauthenticated user.
						break;
					default:
						setModalState({ shown: true, message: ErrorWithResponse(axiosError) });
						break;
				}
			} else setModalState({ shown: true, message: ErrorWithoutResponse(axiosError) });
		}
	}, []);

	if (!initialised) return Loading("Loading the Computer Configurator...");
	else {
		return (
			<AuthenticationSentinel.Provider value={{ userId, setUserId }}>
				<ModalContext.Provider value={{ modalState, setModalState }}>
					<BrowserRouter>
						<span className="overlay fadeIn toTop" />
						<Header />
						<div className="content">
							<Routes>
								<Route path={homeLink} element={<Home />} />
								<Route path={aboutLink} element={<About />} />
								<Route path={partSearchLink} element={<PartManagement />} />
								<Route path={configureComputerLink} element={<ConfigureComputer />} />
							</Routes>
						</div>
					</BrowserRouter>
					{/* <div className="modal" hidden={!modalState.shown}>
						{modalState.message}
						<button onClick={() => setModalState(defaultModalState)}>OK</button>
					</div> */}
				</ModalContext.Provider>
			</AuthenticationSentinel.Provider>
		);
	}
}

export function useModalState() {
	const modalContext = useContext(ModalContext);

	const showModal = useCallback((message: string) => modalContext.setModalState({ shown: true, message }), [modalContext]);

	return showModal;
}

export function useAuthenticationSentinel() {
	const authenticationContext = useContext(AuthenticationSentinel);

	return authenticationContext;
}
