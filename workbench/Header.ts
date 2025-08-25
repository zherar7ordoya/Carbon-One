// src/ui/Header.ts
import { getState, subscribe } from "../app";

export const initHeader = () => {
    const titleEl = document.getElementById("title");
    const frameEl = document.getElementById("frame") as HTMLIFrameElement;
    const openSiteEl = document.getElementById("openSite") as HTMLAnchorElement;
    const socialsEl = document.getElementById("socials");

    const render = () => {
        const { current } = getState();
        if (current) {
            if (titleEl) {
                titleEl.textContent = current.nombre;
            }
            openSiteEl.href = current.web || "#";
            frameEl.src = current.web || "about:blank";
            if (socialsEl) {
                socialsEl.innerHTML = "";
                if (current.facebook) {
                    appendSocial("fab fa-facebook", current.facebook);
                }
                if (current.twitter) {
                    appendSocial("fab fa-x-twitter", current.twitter);
                }
                if (current.instagram) {
                    appendSocial("fab fa-instagram", current.instagram);
                }
                if (current.youtube) {
                    appendSocial("fab fa-youtube", current.youtube);
                }
            }
        } else {
            if (titleEl) {
                titleEl.innerHTML = 'Seleccioná un medio<span class="dot">.</span>';
            }
            openSiteEl.href = "#";
            frameEl.src = "";
            if (socialsEl) {
                socialsEl.innerHTML = "";
            }
        }
    };

    const appendSocial = (iconClass: string, url: string) => {
        const a = document.createElement("a");
        a.href = url;
        a.target = "_blank";
        a.rel = "noopener";
        a.innerHTML = `<i class="${iconClass}"></i>`;
        if (socialsEl) {
            socialsEl.appendChild(a);
        }
    };

    subscribe(render);
};